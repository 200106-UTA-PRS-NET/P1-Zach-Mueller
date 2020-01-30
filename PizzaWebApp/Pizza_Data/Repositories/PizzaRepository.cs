using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pizza_Data.Models;

namespace Pizza_Data.Repositories 
{
    public class PizzaRepository : PizzaLib.Abstractions.IPizzaRepository<Pizzas>
    {
        OOPContext pdb;

        public PizzaRepository()
        {
            pdb = new OOPContext();
        }

        public PizzaRepository(OOPContext pdb)
        {
            this.pdb = pdb ?? throw new ArgumentNullException(nameof(pdb));
        }


        public IEnumerable<Pizzas> GetPizzas()
        {
            var query = from e in pdb.Pizzas
                        select e;

            return query;
        }

        public void AddPizza(Pizzas pizzas)
        {
            if (pdb.Pizzas.Any(e => e.PizzaId == pizzas.PizzaId) || pizzas.PizzaId == null)
            {
                Console.WriteLine($"This pizza {pizzas.PizzaId} is already in production, please select another");
                return;
            }
            else
                pdb.Pizzas.Add(pizzas);
            pdb.SaveChanges();
        }

        public void ModifyPizza(Pizzas pizzas)
        {
            if (pdb.Pizzas.Any(e => e.PizzaId == pizzas.PizzaId))
            {
                var piz = pdb.Pizzas.FirstOrDefault(e => e.PizzaId == pizzas.PizzaId);
                piz.Crust = pizzas.Crust;
                piz.Size = pizzas.Size;
                pdb.Pizzas.Update(piz);
                pdb.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Account with username {pizzas.PizzaId} does not exists, please ensure credentials have been typed correctly");
            }
        }

        public void RemovePizza(int id)
        {
            var piz = pdb.Pizzas.FirstOrDefault(e => e.PizzaId == id);
            if (piz.PizzaId == id)
            {
                pdb.Remove(piz);
                pdb.SaveChanges();
            }
            else
            {
                Console.WriteLine($"pizza with id {id} was never made");
                return;
            }
        }        
        
    }
}
