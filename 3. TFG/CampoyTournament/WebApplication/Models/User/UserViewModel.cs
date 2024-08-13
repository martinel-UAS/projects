using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models.User
{
    public class UserViewModel : BaseViewModel
    {
        public UserViewModel()
        {
            this.AvailableRoles = new List<SelectListItem>();
        }

        [Display(Name = "Nombre:")]
        public string Name { get; set; }

        [Display(Name = "Apellido:")]
        public string Surname { get; set; }

        [Display(Name = "Correo electrónico:")]
        public string Email { get; set; }

        [StringLength(10, ErrorMessage = "El password debe ser entre 5 y 10 caracteres", MinimumLength = 5)]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Repita Password:")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Los passwords no coinciden")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Tipo de usuario")]
        public IList<SelectListItem> AvailableRoles { get; set; }
        [Display(Name = "Tipo de usuario")]
        public int RoleId { get; set; }

        [Display(Name = "Tipo de usuario")]
        public string RoleName { get; set; }

        public int PlayerId { get; set; }
    }
}