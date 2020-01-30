﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaLib;
using PizzaLib.Abstractions;
using PizzaWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_Data.Repositories;

namespace PizzaWebApp.Controllers
{
    
    public class UserController : Controller
    {
        
        private readonly IUserRepository<Pizza_Data.Models.User> _repository;

        public UserController(IUserRepository<Pizza_Data.Models.User> repository)
        {
            _repository = repository;
        }

        
        //GET USERS
        public IActionResult Index()
        {
            var users = _repository.GetUsers();
            List<UserViewModel> uvm = new List<UserViewModel>();
            foreach (var item in users)
            {
                UserViewModel use = new UserViewModel();
                use.Username = item.Username;
                use.Pass = item.Pass;                           
                uvm.Add(use);
            }
            return View(uvm);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    Pizza_Data.Models.User use = new Pizza_Data.Models.User()
                    {
                        Username = user.Username,
                        Pass = user.Pass,
                        
                    };

                    
                    _repository.AddUser(use);

                    return View("~/Views/Home/Index.cshtml");
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(UserViewModel user)
        {
            SessionStorage.total = 0;
            Pizza_Data.Repositories.UserRepository UR = new Pizza_Data.Repositories.UserRepository();
                var useGet = UR.GetUsers();
                foreach (var use in useGet)
                {
                    if (use.Username == user.Username && use.Pass == user.Pass)
                    {
                    SessionStorage.username = user.Username;
                    return RedirectToAction("MainMenu","Home");
                    }
                }
                return View();
            
        }
    }
}