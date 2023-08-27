using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.DTOs
{
    public class AuthorReadDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookReadDTO> Books { get; set; } = new List<BookReadDTO>();
    }
}