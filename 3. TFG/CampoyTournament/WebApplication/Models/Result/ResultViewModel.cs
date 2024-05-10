using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Field;

namespace WebApplication.Models.Result
{
    public partial class ResultViewModel : BaseViewModel
    {
        public ResultViewModel()
        {            
            AvailableResults = new List<SelectListItem>();
            AvailableMatches = new List<SelectListItem>();
            NumberOfPlayers = new List<SelectListItem>();

            //Set NumberOfPlayers initial values
            for (int i = 0; i < 8; i++)
            {
                NumberOfPlayers.Add(new SelectListItem() { Text = (i + 1).ToString(), Value = (i + 1).ToString() });
            }

        }
        [Display(Name = "Evento")]
        public IList<SelectListItem> AvailableResults { get; set; }
        [Display(Name = "Evento")]
        public IList<SelectListItem> AvailableMatches { get; set; }
        [Display(Name = "Jugadores")]
        public IList<SelectListItem> NumberOfPlayers { get; set; }

        public int numberOfPlayers { get; set; }

    }
}