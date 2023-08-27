using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.DTOs
{
    public class AuthorCreateDTO
    {
        public string Name { get; set; }

        public ICollection<BookCreateDTO> Books { get; set; } = new List<BookCreateDTO>();
    }
}