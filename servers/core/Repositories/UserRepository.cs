using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Configurations;
using ReadersCorner.Core.Repositories.Interfaces;

namespace ReadersCorner.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User Add(User user)
        {
            var result = _context.Users.Add(user);
            _ = SaveChanges();
            return result.Entity;
        }

        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(user => user.Id == userId);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Update(User user)
        {
            var result = _context.Update(user);
            _ = SaveChanges();
            return result.Entity;
        }

        public bool Delete(User user)
        {
            _context.Users.Remove(user);
            return SaveChanges();            
        }

        public Task<User> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        private bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}