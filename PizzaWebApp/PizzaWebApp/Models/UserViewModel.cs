using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Pizza_Data;


namespace PizzaWebApp.Models
{
    public class UserViewModel
    {

        [Required]
        public string Username { get; set; }
        [Required]
        public string Pass { get; set; }

      
    }
}
