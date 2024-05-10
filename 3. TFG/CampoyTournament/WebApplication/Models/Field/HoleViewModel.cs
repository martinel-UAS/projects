using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models.Field
{
    public class HoleViewModel
    {
        public HoleViewModel()
        {
            Handicaps = new List<SelectListItem>();
            AvailablesStrikes = new List<SelectListItem>();

            //Set handicaps initial value
            Handicaps.Add(new SelectListItem() { Text = "", Value = null, Selected = true });

            //Set handicaps initial values
            for (int i = 0; i < 18; i++)
            {
                Handicaps.Add(new SelectListItem() { Text = (i+1).ToString(), Value = (i+1).ToString()});
                Par = 3;
                Strikes = 0;
            }

            //Set AvailablesStrikes initial values
            for (int i = 0; i < 7; i++)
            {
                AvailablesStrikes.Add(new SelectListItem() { Text = (i+1).ToString(), Value = (i+1).ToString()});
            }

            AvailablesStrikes.ElementAt(2).Selected = true;
            
        }
        
        public int HoleId { get; set; }

        [Display(Name = "Distancia")]
        public int Distance { get; set; }

        public int Handicap { get; set; }
        public IList<SelectListItem> Handicaps { get; set; }

        public int Par { get; set; }
        public int Strikes { get; set; }
        public int StablefordPoints { get; set; }

        public int SelectedStrikes { get; set; }
        public IList<SelectListItem> AvailablesStrikes { get; set; }
       
    }
}