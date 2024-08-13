using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Contact
{
    public class ContactViewModel : BaseViewModel
    {
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Display(Name = "Mensaje")]
        public string Message { get; set; }
    }
}