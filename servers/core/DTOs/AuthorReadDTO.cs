using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.DTOs
{
    public class AuthorReadDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}