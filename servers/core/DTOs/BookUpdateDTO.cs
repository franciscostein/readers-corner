namespace ReadersCorner.Core.DTOs
{
    public class BookUpdateDTO
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public AuthorReadDTO Author { get; set; }
    }
}