using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Field;

namespace WebApplication.Models.Result
{
    public partial class PlayerScoreCardModel
    {
        public PlayerScoreCardModel() 
        {
            Players = new List<SelectListItem>();
        }
               
        public IList<HoleViewModel> ScoreCard { get; set; }

        public IList<SelectListItem> Players { get; set; }
        public int PlayerSelected { get; set; }

        public double PlayerGameHP { get; set; }

        public int TotalStrikes { get; set; }
        public int TotalStableFordPoints { get; set; }
        public string PlayerName { get; set; }
        public string PlayerLicense { get; set; }
    }
}