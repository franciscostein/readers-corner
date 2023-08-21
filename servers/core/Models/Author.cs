using System.ComponentModel.DataAnnotations;

namespace ReadersCorner.Core.Models
{
    public class Author
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}