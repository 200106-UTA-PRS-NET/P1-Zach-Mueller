using System;
using System.Collections.Generic;

namespace PizzaLib
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public decimal TotalCharges { get; set; }
        public string PlacedAt { get; set; }
        public string Username { get; set; }
        public string StoreName { get; set; }

        public virtual Store StoreNameNavigation { get; set; }
        public virtual User UsernameNavigation { get; set; }
        public virtual CompletedOrders CompletedOrders { get; set; }
    }
}
