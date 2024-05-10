using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Remind
{
    public class RemindModel
    {
        [Display(Name = "Correo electrónico:")]
        public string Email { get; set; }
    }
}