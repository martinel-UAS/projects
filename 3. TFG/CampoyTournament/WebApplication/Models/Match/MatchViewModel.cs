using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Field;

namespace WebApplication.Models.Match
{
    public class MatchViewModel : BaseViewModel
    {
        public MatchViewModel() 
        {
            this.AvailableFields = new List<SelectListItem>();
            this.KindOfEvents = new List<SelectListItem>();

            this.FutureMatchs = new List<MatchViewModel>();
            this.RecentMatchs = new List<MatchViewModel>();
        }

        public int FieldId { get; set; }

        [Display(Name = "Campo")]
        public string FieldName { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = ("{0:dd-MMM-yyyy}"))]
        public DateTime Date { get; set; }

        [Display(Name = "Tipo de evento")]
        public string KindOfEvent { get; set; }
        
        public IList<MatchViewModel> FutureMatchs { get; set; }
        public IList<MatchViewModel> RecentMatchs { get; set; }
        
        public IList<SelectListItem> AvailableFields { get; set; }
        public IList<SelectListItem> KindOfEvents { get; set; }

        public bool HasResults { get; set; }
    }
}