using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaWebApp.Models;
using PizzaLib;
using PizzaLib.Abstractions;
using Pizza_Data.Repositories;

namespace PizzaWebApp.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository<Pizza_Data.Models.Pizzas> _repository;

        public PizzaController(IPizzaRepository<Pizza_Data.Models.Pizzas> repository)
        {
            _repository = repository;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrderUp()
        {
            OrderRepository gg = new OrderRepository();
            var ords = gg.GetOrders();

            foreach (var ord in ords) { 

            if (ord.Username == SessionStorage.username && ord.PlacedAt == DateTime.Today.ToString("dd-MM-yyyy"))
                {
                    return RedirectToAction("SlowDown", "Pizza");
                } 
            }
            return View();
        }

        public IActionResult SlowDown()
        {
            return View();
        }

        public IActionResult Option()
        {
            return View();
        }

        public IActionResult Make()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Make(PizzaViewModel pizza)
        {

            try
            {

                decimal charge = 0;
                if (pizza.Size == "Small")
                {
                    charge = 8;
                    SessionStorage.total += charge;
                }
                else if (pizza.Size == "Medium")
                {
                    charge = 12;
                    SessionStorage.total += charge;
                }
                else if (pizza.Size == "Large")
                {
                    charge = 15;
                    SessionStorage.total += charge;
                }

                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here

                    Pizza_Data.Models.Pizzas piz = new Pizza_Data.Models.Pizzas()


                    {
                        PizzaType = pizza.PizzaType,
                        Crust = pizza.Crust,
                        Size = pizza.Size,
                        Username = SessionStorage.username,
                        Price = charge
                    };


                    _repository.AddPizza(piz);

                    return RedirectToAction("Option", "Pizza");
                }
                else

                ModelState.AddModelError(string.Empty, "Please ensure all options have been checked.");
                return View();
            }
            catch
            {

                ModelState.AddModelError(string.Empty, "Please ensure all options have been checked.");
                return View();
            }
        }
            
    }
}
