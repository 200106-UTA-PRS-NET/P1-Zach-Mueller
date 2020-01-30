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
    public class OrderController : Controller
    {
        private readonly IOrderRepository<Pizza_Data.Models.Orders> _repository;
        public OrderController(IOrderRepository<Pizza_Data.Models.Orders> repository)
        {
            _repository = repository;
        }


        public IActionResult Clearance()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult Clearance(string cc)
        {

            if (cc == "OOP0412")
            {
                return RedirectToAction("Index", "Order");
            }
            return View();
        }

        public IActionResult Index()
        {
            var orders = _repository.GetOrders();
            List<Pizza_Data.Models.Orders> ovm = new List<Pizza_Data.Models.Orders>();
            foreach (var item in orders)
            {
                Pizza_Data.Models.Orders ord = new Pizza_Data.Models.Orders();
                ord.OrderId = item.OrderId;
                ord.TotalCharges = item.TotalCharges;
                ord.PlacedAt = item.PlacedAt;
                ord.Username = item.Username;
                ord.StoreName = item.StoreName;

                ovm.Add(ord);
            }
            return View(ovm);
        }

        public IActionResult UserOrders()
        {
            var orders = _repository.GetOrders();
            List<Pizza_Data.Models.Orders> ovm = new List<Pizza_Data.Models.Orders>();
            Pizza_Data.Repositories.UserRepository GU = new Pizza_Data.Repositories.UserRepository();
            string thisUser = GU.CurrentUser; 
            foreach (var item in orders)
            {
               if (item.Username == PizzaLib.SessionStorage.username)
                {
                    Pizza_Data.Models.Orders ord = new Pizza_Data.Models.Orders();
                    ord.OrderId = item.OrderId;
                    ord.TotalCharges = item.TotalCharges;
                    ord.PlacedAt = item.PlacedAt;
                    ord.Username = item.Username;
                    ord.StoreName = item.StoreName;

                    ovm.Add(ord);
                }
            }
            return View(ovm);
        }

        
        public IActionResult Finish()
        {

            string today = DateTime.Today.ToString("dd-MM-yyyy");
            Pizza_Data.Models.Orders ord = new Pizza_Data.Models.Orders()
            {
                TotalCharges = SessionStorage.total,
                PlacedAt = today,
                Username = SessionStorage.username,
                StoreName = "Object Oriented Pizza"
            };

            _repository.AddOrders(ord);
            return View();

        }

       
    }
}