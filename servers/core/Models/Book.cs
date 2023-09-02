using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ReadersCorner.Core.Models.Interfaces;

namespace ReadersCorner.Core.Models
{
    public class Book : IModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
}