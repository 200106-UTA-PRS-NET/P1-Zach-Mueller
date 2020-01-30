using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Abstractions
{
    public interface IUserRepository<T>
    {
        
        IEnumerable<T> GetUsers();
        void AddUser(T user);
        void ModifyUser(T user);
        void RemoveUser(string user);
    }
}
