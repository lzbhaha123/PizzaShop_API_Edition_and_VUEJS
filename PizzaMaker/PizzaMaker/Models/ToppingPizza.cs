using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaMaker.Models
{
    public class ToppingPizza
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Guid PizzaId { get; set; }
        [Required]
        public Pizza? Pizza { get; set; }
        [Required]
        public Guid ToppingId { get; set; }
        [Required]
        public Topping? Topping { get; set; }
        [Required]
        public int ToppingSize { get; set; }
    }
}
