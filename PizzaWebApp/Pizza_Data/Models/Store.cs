﻿using System;
using System.Collections.Generic;

namespace Pizza_Data.Models
{
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Orders>();
        }

        public string StoreName { get; set; }
        public string Venue { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
