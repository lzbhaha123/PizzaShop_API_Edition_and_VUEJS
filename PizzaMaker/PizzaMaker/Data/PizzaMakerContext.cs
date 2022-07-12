using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaMaker.Models;

namespace PizzaMaker.Data
{
    public class PizzaMakerContext : DbContext
    {
        public PizzaMakerContext (DbContextOptions<PizzaMakerContext> options)
            : base(options)
        {
        }

        public DbSet<PizzaMaker.Models.Topping>? Topping { get; set; }
        public DbSet<PizzaMaker.Models.Pizza>? Pizza { get; set; }
        public DbSet<PizzaMaker.Models.ToppingPizza>? ToppingPizza { get; set; }
    }
}
