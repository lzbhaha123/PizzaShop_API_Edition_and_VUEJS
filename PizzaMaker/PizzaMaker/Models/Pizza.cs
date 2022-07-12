using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaMaker.Models
{
    public class Pizza
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PizzaId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Image { get; set; }
    }

}
