using System.ComponentModel.DataAnnotations;
using ReadersCorner.Core.Models.Interfaces;

namespace ReadersCorner.Core.Models
{
    public class Author : IModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}