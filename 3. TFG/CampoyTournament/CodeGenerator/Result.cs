

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martínez Palomino</CreatedBy>
///<DateCreated>05/07/2014 19:54:19</DateCreated>
///<DateModified>05/07/2014 19:54:19</DateModified>
///<Observations>Result entity</Observations>
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
    /// 	This class represents a 'Result'
    /// </summary>
    public class Result : BaseEntity
    {
			/// <summary>
                /// 	Gets or sets the HoleId
                /// </summary>
        		public int HoleId { get; set; }
        	/// <summary>
                /// 	Gets or sets the MatchId
                /// </summary>
        		public int MatchId { get; set; }
        	/// <summary>
                /// 	Gets or sets the PlayerId
                /// </summary>
        		public int PlayerId { get; set; }
        	/// <summary>
                /// 	Gets or sets the Strikes
                /// </summary>
        		public int Strikes { get; set; }
        	/// <summary>
                /// 	Gets or sets the Handicap
                /// </summary>
        		public Double Handicap { get; set; }
 
		 
    }
}

