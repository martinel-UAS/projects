using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Field
{
    public class FieldViewModel : BaseViewModel
    {
        public FieldViewModel() 
        { 
            Holes = new List<HoleViewModel>();
        }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Display(Name = "Província")]
        public string Province { get; set; }
        
        [Display(Name = "Página Web")]
        public string Web { get; set; }
        
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
        
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }
        
        public IList<HoleViewModel> Holes { get; set; }        
    }
}