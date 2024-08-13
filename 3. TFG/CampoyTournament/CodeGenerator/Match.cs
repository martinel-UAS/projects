

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martínez Palomino</CreatedBy>
///<DateCreated>05/07/2014 19:54:18</DateCreated>
///<DateModified>05/07/2014 19:54:18</DateModified>
///<Observations>Match entity</Observations>
//************************************************************
//************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DomainEntities
{
    /// <summary>
    /// 	This class represents a 'Match'
    /// </summary>
    public class Match : BaseEntity
    {
			/// <summary>
                /// 	Gets or sets the TournamentId
                /// </summary>
        		public int TournamentId { get; set; }
        	/// <summary>
                /// 	Gets or sets the FieldId
                /// </summary>
        		public int FieldId { get; set; }
        	/// <summary>
                /// 	Gets or sets the Date
                /// </summary>
        		public DateTime Date { get; set; }
        	/// <summary>
                /// 	Gets or sets the IsTournament
                /// </summary>
        		public bool IsTournament { get; set; }
 
			/// <summary>
                /// 	Gets or sets the Result
                /// </summary>
        		private ICollection<Result> results;
        		public ICollection<Result> Results
                {
                    get { return results ?? (results = new List<Result>()); }
                    set { results = value; }
                }
 
    }
}

