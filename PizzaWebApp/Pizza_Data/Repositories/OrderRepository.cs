using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pizza_Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Pizza_Data.Repositories
{
    public class OrderRepository : PizzaLib.Abstractions.IOrderRepository<Orders>
    {
        OOPContext pdb;

        public OrderRepository()
        {
            pdb = new OOPContext();
        }

        public OrderRepository(OOPContext pdb)
        {
            this.pdb = pdb ?? throw new ArgumentNullException(nameof(pdb));
        }
        public IEnumerable<Orders> GetOrders()
        {
            var query = from e in pdb.Orders
                        select e;

            return query;
        }

        public void AddOrders(Orders orders)
        {
            if (pdb.Orders.Any(e => e.OrderId == orders.OrderId) || orders.OrderId == null)
            {
                Console.WriteLine($"The order {orders.OrderId} is already being processed");
                return;
            }
            else
                pdb.Orders.Add(orders);
            pdb.SaveChanges();
        }

        public void ModifyOrders(Orders orders)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrders(int id)
        {
            throw new NotImplementedException();
        }
    }
}



