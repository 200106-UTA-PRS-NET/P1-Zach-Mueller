using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Pizza_Data;

namespace PizzaWebApp.Models
{
    public class PizzaViewModel
    {
        public int PizzaId { get; set; }
        [Required(ErrorMessage = "Crust must have a selection")]
        
        public string Crust { get; set; }
        [Required(ErrorMessage = "Size must have a selection")]
        public string Size { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "Type must have a selection")]
        public string PizzaType { get; set; }
        public decimal Price { get; set; }
    }
}
