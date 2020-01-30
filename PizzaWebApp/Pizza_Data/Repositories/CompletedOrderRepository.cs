using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pizza_Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Pizza_Data.Repositories
{
   public class CompletedOrderRepository : PizzaLib.Abstractions.ICompletedOrderRepository<CompletedOrders>
    {
        OOPContext pdb;

        public CompletedOrderRepository()
        {
            pdb = new OOPContext();
        }

        public CompletedOrderRepository(OOPContext pdb)
        {
            this.pdb = pdb ?? throw new ArgumentNullException(nameof(pdb));
        }

        public IEnumerable<CompletedOrders> GetCompletedOrders()
        {
            var query = from e in pdb.CompletedOrders
                        select e;

            return query;
        }

        public void AddCompletedOrder(CompletedOrders completedorders)
        {
            if (pdb.CompletedOrders.Any(e => e.OrderId == completedorders.OrderId) || completedorders.OrderId == null)
            {
                Console.WriteLine($"The order {completedorders.OrderId} is already being processed");
                return;
            }
            else
                pdb.CompletedOrders.Add(completedorders);
            pdb.SaveChanges();
        }

        public void ModifyCompletedOrder(CompletedOrders completedorders)
        {
            throw new NotImplementedException();
        }

        public void RemoveCompletedOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
