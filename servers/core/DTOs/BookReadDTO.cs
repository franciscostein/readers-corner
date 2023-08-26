using ReadersCorner.Core.Models;

namespace ReadersCorner.Core.DTOs
{
    public class BookReadDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public Author Author { get; set; }
    }
}