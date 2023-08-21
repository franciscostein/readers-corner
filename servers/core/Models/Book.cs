using System.ComponentModel.DataAnnotations;

namespace ReadersCorner.Core.Models
{
    public class Book
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public Author Author { get; set; }
    }
}