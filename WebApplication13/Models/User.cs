using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public class User
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Заполните Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Заполните Login")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Заполните Password")]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [ValidateNever]
        public DateTime DateRegister { get; set; }
    }
}
