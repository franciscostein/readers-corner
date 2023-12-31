using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.DTOs
{
    public class BookCreateDTO
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public AuthorReadDTO Author { get; set; }
    }
}