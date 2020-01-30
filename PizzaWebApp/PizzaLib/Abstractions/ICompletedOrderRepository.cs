using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Abstractions
{
    public interface ICompletedOrderRepository<T>
    {
        IEnumerable<T> GetCompletedOrders();
        void AddCompletedOrder(T completedOrder);
        void ModifyCompletedOrder(T completedOrder);
        void RemoveCompletedOrder(int id);
    }
}
