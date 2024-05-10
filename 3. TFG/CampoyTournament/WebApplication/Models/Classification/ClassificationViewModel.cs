using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Classification
{
    public class ClassificationViewModel
    {
        public int PlayerId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Licencia")]
        public string PlayerLicense { get; set; }

        [Display(Name = "Nombre")]
        public string PlayerName { get; set; }

        [Display(Name = "Jugados")]
        public int GamesPlayed { get; set; }

        [Display(Name = "Descartados")]
        public int GamesDiscarted { get; set; }

        [Display(Name = "Total")]
        public int TotalGames { get; set; }

        [Display(Name = "Golpes")]
        public int TotalStrikes { get; set; }

        [Display(Name = "Puntos")]
        public int TotalPoints { get; set; }
    }
}