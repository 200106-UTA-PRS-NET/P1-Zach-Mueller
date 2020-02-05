using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pizza_Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Pizza_Data.Repositories
{
   public class StoreRepository : PizzaLib.Abstractions.IStoreRepository<Store>
    {
        OOPContext pdb;

       

        public StoreRepository(OOPContext pdb)
        {
            this.pdb = pdb ?? throw new ArgumentNullException(nameof(pdb));
        }

        public IEnumerable<Store> GetStores()
        {
            var query = from e in pdb.Store
                        select e;

            return query;
        }

        public void AddStore(Store store)
        {
            if (pdb.Store.Any(e => e.StoreName == store.StoreName) || store.StoreName == null)
            {
                Console.WriteLine($"The username {store.StoreName} is already in use, please select another");
                return;
            }
            else
                pdb.Store.Add(store);
            pdb.SaveChanges();
        }

        public void ModifyStore(Store store)
        {
            if (pdb.Store.Any(e => e.StoreName == store.StoreName))
            {
                var sto = pdb.Store.FirstOrDefault(e => e.StoreName == store.StoreName);
                sto.Venue = store.Venue;
                pdb.Store.Update(sto);
                pdb.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Account with username {store.StoreName} does not exists, please ensure credentials have been typed correctly");
            }
        }

        public void RemoveStore(string name)
        {
            var nam = pdb.Store.FirstOrDefault(e => e.StoreName == name);
            if (nam.StoreName == name)
            {
                pdb.Remove(nam);
                pdb.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Store with name {name} does not exist");
                return;
            }
        }
    }
}
