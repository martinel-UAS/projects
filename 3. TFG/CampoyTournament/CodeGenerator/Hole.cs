

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martínez Palomino</CreatedBy>
///<DateCreated>05/07/2014 19:54:17</DateCreated>
///<DateModified>05/07/2014 19:54:17</DateModified>
///<Observations>Hole entity</Observations>
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
    /// 	This class represents a 'Hole'
    /// </summary>
    public class Hole : BaseEntity
    {
			/// <summary>
                /// 	Gets or sets the FieldId
                /// </summary>
        		public int FieldId { get; set; }
        	/// <summary>
                /// 	Gets or sets the Handicap
                /// </summary>
        		public int Handicap { get; set; }
        	/// <summary>
                /// 	Gets or sets the Distance
                /// </summary>
        		public int Distance { get; set; }
 
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

