using System;
using System.Collections.Generic;

namespace PizzaLib
{
    public partial class CompletedOrders
    {
        public int OrderId { get; set; }

        public virtual Orders Order { get; set; }
    }
}
