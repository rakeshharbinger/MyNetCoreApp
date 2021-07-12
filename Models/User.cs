using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyNetCoreApp.Models
{
    public class User
    {
        [Display(Order = 0)]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        [Display(Order = 1)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        [Display(Order = 2)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Please enter email address")]
        [Display(Order = 3)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Order = 4)]
        public string Password { get; set; }
    }
}
