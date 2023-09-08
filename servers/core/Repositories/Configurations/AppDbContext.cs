using Microsoft.EntityFrameworkCore;
using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.Repositories.Configurations
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}