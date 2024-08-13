using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Profile
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        [Display(Name = "Password actual:")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Display(Name = "Nuevo password:")]
        [StringLength(10, ErrorMessage = "El password debe ser entre 5 y 10 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Confirme password:")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Los passwords no coinciden")]
        public string ConfirmNewPassword { get; set; }
    }
}