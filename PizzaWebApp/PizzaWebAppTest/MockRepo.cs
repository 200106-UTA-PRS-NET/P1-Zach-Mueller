using System;
using System.Collections.Generic;
using System.Text;
using PizzaWebApp.Controllers;
using PizzaLib.Abstractions;
using Pizza_Data.Models;

namespace PizzaWebAppTest
{
    public class MockRepo : IPizzaRepository<Pizza_Data.Models.Pizzas>, IOrderRepository<Pizza_Data.Models.Orders>, IStoreRepository<Pizza_Data.Models.Store>, IUserRepository<Pizza_Data.Models.User>, ICompletedOrderRepository<Pizza_Data.Models.CompletedOrders>
    {

        static IEnumerable<Pizza_Data.Models.Pizzas> pizzas = new List<Pizza_Data.Models.Pizzas>() {
            new Pizzas(){
            PizzaId = 1,
            Crust = "Hand Tossed",
            Size = "Large",
            Username="Lil",
            PizzaType="Cheese",
            Price=15,
            },
            new Pizzas(){
            PizzaId=2,
            Crust = "Cheese Stuffed",
            Size = "Medium",
            Username="Bojangles",
            PizzaType="Pepperoni",
            Price=12,

            }

        };

        static IEnumerable<Pizza_Data.Models.Orders> orders = new List<Pizza_Data.Models.Orders>()
        {
            new Orders(){
            OrderId = 1,
            TotalCharges = 20,
            PlacedAt = DateTime.Today.ToString("dd-MM-yyyy"),
            Username = "GoodSir",
            StoreName = "OOP"
            },
            new Orders(){
            OrderId=2,
            TotalCharges = 35,
            PlacedAt = DateTime.Today.ToString("dd-MM-yyyy"),
            Username="poppop",
            StoreName="OOP"          
            }

        };

        static IEnumerable<Pizza_Data.Models.CompletedOrders> Comporders = new List<Pizza_Data.Models.CompletedOrders>()
        {
            new CompletedOrders(){
            OrderId = 1,
            
            },
            new CompletedOrders(){
            OrderId=2,
          
            }

        };

        static IEnumerable<Pizza_Data.Models.Store> store = new List<Pizza_Data.Models.Store>()
        {
            new Store(){
            StoreName = "Big Caesers",
            Venue = "Denver CO"
            },
            new Store(){
            StoreName = "Mama Johns",
            Venue = "Maryville MO"
            }

        };

        static IEnumerable<Pizza_Data.Models.User> user = new List<Pizza_Data.Models.User>()
        {
            new User(){
            Username = "Carpe",
            Pass = "Diem"
            },
            new User(){
            Username = "Mock",
            Pass = "Repo"
            }

        };


        public void AddPizza(Pizzas pizzas)
        {
            throw new NotImplementedException();
        }

        public void ModifyPizza(Pizzas pizzas)
        {
            throw new NotImplementedException();
        }

        public void RemovePizza(int id)
        {
            throw new NotImplementedException();
        }



        IEnumerable<Pizzas> IPizzaRepository<Pizzas>.GetPizzas()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Orders> GetOrders()
        {
            throw new NotImplementedException();
        }

        public void AddOrders(Orders orders)
        {
            throw new NotImplementedException();
        }

        public void ModifyOrders(Orders orders)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrders(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Store> GetStores()
        {
            throw new NotImplementedException();
        }

        public void AddStore(Store stores)
        {
            throw new NotImplementedException();
        }

        public void ModifyStore(Store stores)
        {
            throw new NotImplementedException();
        }

        public void RemoveStore(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void ModifyUser(User user)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompletedOrders> GetCompletedOrders()
        {
            throw new NotImplementedException();
        }

        public void AddCompletedOrder(CompletedOrders completedOrder)
        {
            throw new NotImplementedException();
        }

        public void ModifyCompletedOrder(CompletedOrders completedOrder)
        {
            throw new NotImplementedException();
        }

        public void RemoveCompletedOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pizzas> GetPizzas()
        {
            throw new NotImplementedException();
        }

        

        
    }
}
