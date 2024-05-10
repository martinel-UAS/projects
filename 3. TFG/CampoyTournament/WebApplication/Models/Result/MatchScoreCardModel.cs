using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Result
{
    public partial class MatchScoreCardModel
    {
        public int MatchId { get; set; }

        public string FieldName { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = ("{0:dd-MMM-yyyy}"))]
        public DateTime Date { get; set; }

        public IList<PlayerScoreCardModel> ScoreCards { get; set; }
    }
}