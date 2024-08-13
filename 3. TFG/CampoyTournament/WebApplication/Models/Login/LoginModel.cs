using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Login
{
    public class LoginModel
    {
        [Display(Name = "Correo electrónico:")]
        public string Email { get; set; }

        [StringLength(10, ErrorMessage = "El password debe ser entre 5 y 10 caracteres", MinimumLength = 5)]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string RedirectUrl { get; set; }
        public string Role { get; set; }

    }
}