using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PizzaMaker.Data;
using System;
using System.Linq;

namespace PizzaMaker.Models
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PizzaMakerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PizzaMakerContext>>()))
            {
                // Look for any movies.
                if (!context.Topping.Any())
                {
                    context.Topping.AddRange(new List<Topping> {
                        new Topping
                        {
                            Name = "Ham",
                            Price = 2.00,
                        },
                        new Topping
                        {
                            Name = "Pineapple",
                            Price = 2.00
                        },
                        new Topping
                        {
                            Name = "Cheese",
                            Price = 1.00
                        },
                    });
                }
                if (!context.Pizza.Any())
                {
                    context.Pizza.AddRange(new List<Pizza>
                    {
                        new Pizza
                        {
                            Name = "Ham Pizza",
                            Image = "https://www.dominos.co.nz/ManagedAssets/NZ/product/P099XL/NZ_P099XL_en_hero_8342.jpg?v163941431"
                        },
                        new Pizza
                        {
                            Name = "Hawaii Pizza",
                            Image="https://www.budgetbytes.com/wp-content/uploads/2010/07/Spicy-Hawaiian-Pizza.jpg"
                        },
                        new Pizza
                        {
                            Name = "Cheese Pizza",
                            Image="https://kitchenatics.com/wp-content/uploads/2020/09/Cheese-pizza-1.jpg"
                        }
                    });
                }
                    
                context.SaveChanges();
                List<Pizza> pizzas = context.Pizza.ToList();
                Pizza p1 = pizzas[0];
                Pizza p2 = pizzas[2];
                Pizza p3 = pizzas[1];
                List<Topping> toppings = context.Topping.ToList();
                Topping t1 = toppings[0];
                Topping t2 = toppings[1];
                Topping t3 = toppings[2];
                if (!context.ToppingPizza.Any()) {
                    context.ToppingPizza.AddRange(new List<ToppingPizza>
                    {
                        new ToppingPizza
                        {
                            Pizza = p1,
                            Topping= t1,
                            ToppingSize=1
                        },
                        new ToppingPizza
                        {
                            Pizza = p1,
                            Topping= t2,
                            ToppingSize=1
                        },
                        new ToppingPizza
                        {
                            Pizza = p1,
                            Topping= t3,
                            ToppingSize=1
                        },
                        new ToppingPizza
                        {
                            Pizza = p2, 
                            Topping= t2,
                            ToppingSize=1
                        },
                        new ToppingPizza
                        {
                            Pizza = p3,
                            Topping= t1,
                            ToppingSize=1
                        },
                        new ToppingPizza
                        {
                            Pizza = p3,
                            Topping= t2,
                            ToppingSize=1
                        }
                    }); 
                }
                context.SaveChanges();
            }
        }
    }
}
