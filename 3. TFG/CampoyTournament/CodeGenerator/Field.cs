


//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martínez Palomino</CreatedBy>
///<DateCreated>05/07/2014 19:54:16</DateCreated>
///<DateModified>05/07/2014 19:54:16</DateModified>
///<Observations>Field entity</Observations>
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
    /// 	This class represents a 'Field'
    /// </summary>
    public class Field : BaseEntity
    {
			/// <summary>
                /// 	Gets or sets the Name
                /// </summary>
        		public string Name { get; set; }
        	/// <summary>
                /// 	Gets or sets the Address
                /// </summary>
        		public string Address { get; set; }
        	/// <summary>
                /// 	Gets or sets the City
                /// </summary>
        		public string City { get; set; }
        	/// <summary>
                /// 	Gets or sets the Province
                /// </summary>
        		public string Province { get; set; }
        	/// <summary>
                /// 	Gets or sets the Web
                /// </summary>
        		public string Web { get; set; }
        	/// <summary>
                /// 	Gets or sets the Email
                /// </summary>
        		public string Email { get; set; }
        	/// <summary>
                /// 	Gets or sets the Phone
                /// </summary>
        		public string Phone { get; set; }
 
			/// <summary>
                /// 	Gets or sets the Hole
                /// </summary>
        		private ICollection<Hole> holes;
        		public ICollection<Hole> Holes
                {
                    get { return holes ?? (holes = new List<Hole>()); }
                    set { holes = value; }
                }
        	/// <summary>
                /// 	Gets or sets the Match
                /// </summary>
        		private ICollection<Match> matchs;
        		public ICollection<Match> Matchs
                {
                    get { return matchs ?? (matchs = new List<Match>()); }
                    set { matchs = value; }
                }
 
    }
}

