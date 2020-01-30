using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApp.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public decimal TotalCharges { get; set; }
        public string PlacedAt { get; set; }
        public string Username { get; set; }
        public string StoreName { get; set; }
    }
}
