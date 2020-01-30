using System;
using System.Collections.Generic;

namespace Pizza_Data.Models
{
    public partial class CompletedOrders
    {
        public int OrderId { get; set; }

        public virtual Orders Order { get; set; }
    }
}
