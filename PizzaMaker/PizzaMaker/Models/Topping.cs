using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaMaker.Models
{
    public class Topping
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ToppingId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
