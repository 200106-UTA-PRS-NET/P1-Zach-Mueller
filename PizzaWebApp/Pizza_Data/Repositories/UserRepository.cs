using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pizza_Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Pizza_Data.Repositories
{
    
    public class UserRepository : PizzaLib.Abstractions.IUserRepository<User>
    {
        OOPContext pdb;
        

        public UserRepository()
        {
            pdb = new OOPContext();
        }

        public UserRepository(OOPContext pdb)
        {
            this.pdb = pdb ?? throw new ArgumentNullException(nameof(pdb));
        }

        public IEnumerable<User> GetUsers()
        {
            var query = from e in pdb.User
                        select e;

            return query;
        }

        public string CurrentUser { get; set; }

        public void AddUser(User user)
        {
            if (pdb.User.Any(e => e.Username == user.Username) || user.Username == null)
            {
                Console.WriteLine($"The username {user.Username} is already in use, please select another");
                return;
            }
            else
            {

                pdb.User.Add(user);
                pdb.SaveChanges();
                Console.WriteLine("User added successfully");
            }
        }

        public void AuthUser(User user)
        {
            if (pdb.User.Any(e => e.Username == user.Username) && pdb.User.Any(e => e.Pass == user.Pass))
            { Console.WriteLine($"User authenticated successfully. Welcome back {user.Username}"); }
            else
            { Console.WriteLine("Could not find a user with such credentials."); }
        }

        public void ModifyUser(User user)
        {
            if (pdb.User.Any(e => e.Username == user.Username))
            {
                var use = pdb.User.FirstOrDefault(e => e.Username == user.Username);
                use.Pass = user.Pass;
                pdb.User.Update(use);
                pdb.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Account with username {user.Username} does not exists, please ensure credentials have been typed correctly");
            }
        }

        public void RemoveUser(string user)
        {
            var use = pdb.User.FirstOrDefault(e => e.Username == user);
            if (use.Username == user)
            {
                pdb.Remove(use);
                pdb.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Employee with this Id {user} does not exists");
                return;
            }
        }
    }

}
