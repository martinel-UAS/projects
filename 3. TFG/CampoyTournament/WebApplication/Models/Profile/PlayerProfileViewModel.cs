using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Profile
{
    public class PlayerProfileViewModel : UserProfileViewModel
    {      
        [Display(Name = "Licencia")]
        public string License { get; set; }

        [Display(Name = "Apodo")]
        public string Alias { get; set; }

        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [Display(Name = "Handicap Real")]
        public Double RealHP { get; set; }

        [Display(Name = "Handicap de Juego")]
        public Double GameHP { get; set; }  
    }
}