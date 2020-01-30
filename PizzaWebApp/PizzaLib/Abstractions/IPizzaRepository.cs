using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Abstractions
{
   public interface IPizzaRepository<T>
    {
        IEnumerable<T> GetPizzas();
        void AddPizza(T pizzas);
        void ModifyPizza(T pizzas);
        void RemovePizza(int id);
    }
}
