using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Abstractions
{
    public interface IOrderRepository<T>
    {
        IEnumerable<T> GetOrders();
        void AddOrders(T orders);
        void ModifyOrders(T orders);
        void RemoveOrders(int id);
    }
}
