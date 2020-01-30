using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Abstractions
{
   public interface IStoreRepository <T>
    {
        IEnumerable<T> GetStores();
        void AddStore(T stores);
        void ModifyStore(T stores);
        void RemoveStore(string name);
    }
}
