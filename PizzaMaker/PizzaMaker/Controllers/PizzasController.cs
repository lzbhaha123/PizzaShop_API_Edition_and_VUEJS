using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PizzaMaker.Data;
using PizzaMaker.Models;

namespace PizzaMaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly PizzaMakerContext _context;

        public PizzasController(PizzaMakerContext context)
        {
            _context = context;
        }

        // GET: api/Pizzas
        [HttpGet]
        public dynamic GetPizza()
        {
          if (_context.Pizza == null)
          {
              return NotFound();
          }
            IQueryable<object>? ps = from p in _context.Pizza
                                        select new
                                        {
                                            pizza = new
                                            {
                                                id = p.PizzaId,
                                                name = p.Name,
                                                img = p.Image,
                                                total=0,
                                                price = (from tp in _context.ToppingPizza
                                                         join t in _context.Topping
                                                            on tp.ToppingId equals t.ToppingId
                                                         where tp.PizzaId == p.PizzaId select t.Price).Sum(),
                                                toppings = (from tp in _context.ToppingPizza join t in _context.Topping 
                                                            on tp.ToppingId equals t.ToppingId where tp.PizzaId == p.PizzaId select 
                                                            new
                                                            {
                                                                name = t.Name,
                                                                size = tp.ToppingSize
                                                            }).ToList(),
                                            }
                                        };
            return ps.ToList();
        }

        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public dynamic GetPizza(Guid id)
        {
          if (_context.Pizza == null)
          {
              return NotFound();
          }
            IQueryable<object>? ps = from p in _context.Pizza where p.PizzaId == id
                                     select new
                                     {
                                         pizza = new
                                         {
                                             id = p.PizzaId,
                                             name = p.Name,
                                             img = p.Image,
                                             toppings = (from tp in _context.ToppingPizza
                                                         join t in _context.Topping
                                                         on tp.ToppingId equals t.ToppingId
                                                         where tp.PizzaId == p.PizzaId
                                                         select
                                                         new
                                                         {
                                                             name = t.Name,
                                                             price = t.Price,
                                                             size = tp.ToppingSize
                                                         }).ToList(),
                                         }
                                     };
            var pizza = ps.ToList();

            if (pizza == null)
            {
                return NotFound();
            }

            return pizza;
        }

        // PUT: api/Pizzas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizza(Guid id, Pizza pizza)
        {
            if (id != pizza.PizzaId)
            {
                return BadRequest();
            }

            _context.Entry(pizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pizzas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza)
        {
          if (_context.Pizza == null)
          {
              return Problem("Entity set 'PizzaMakerContext.Pizza'  is null.");
          }
            _context.Pizza.Add(pizza);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPizza", new { id = pizza.PizzaId }, pizza);
        }

        // DELETE: api/Pizzas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(Guid id)
        {
            if (_context.Pizza == null)
            {
                return NotFound();
            }
            var pizza = await _context.Pizza.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }

            _context.Pizza.Remove(pizza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaExists(Guid id)
        {
            return (_context.Pizza?.Any(e => e.PizzaId == id)).GetValueOrDefault();
        }
    }
}
