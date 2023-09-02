using System.ComponentModel.DataAnnotations;
using ReadersCorner.Core.Models.Interfaces;

namespace ReadersCorner.Core.Models
{
    public class User : IModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}