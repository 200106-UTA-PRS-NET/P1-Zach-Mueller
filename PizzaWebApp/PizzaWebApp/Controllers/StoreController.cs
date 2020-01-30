using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaLib;
using PizzaLib.Abstractions;
using PizzaWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PizzaWebApp.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreRepository<Pizza_Data.Models.Store> _repository;
        public StoreController(IStoreRepository<Pizza_Data.Models.Store> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var stores = _repository.GetStores();
            List<Pizza_Data.Models.Store> svm = new List<Pizza_Data.Models.Store>();
            foreach (var item in stores)
            {
                Pizza_Data.Models.Store sto = new Pizza_Data.Models.Store();
                sto.StoreName = item.StoreName;            
                sto.Venue = item.Venue;
                
                svm.Add(sto);
            }
            return View(svm);
        }
    }
}