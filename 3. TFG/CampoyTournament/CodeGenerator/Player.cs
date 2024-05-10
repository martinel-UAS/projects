

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martínez Palomino</CreatedBy>
///<DateCreated>05/07/2014 19:54:18</DateCreated>
///<DateModified>05/07/2014 19:54:18</DateModified>
///<Observations>Player entity</Observations>
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
    /// 	This class represents a 'Player'
    /// </summary>
    public class Player : BaseEntity
    {
			/// <summary>
                /// 	Gets or sets the License
                /// </summary>
        		public string License { get; set; }
        	/// <summary>
                /// 	Gets or sets the Alias
                /// </summary>
        		public string Alias { get; set; }
        	/// <summary>
                /// 	Gets or sets the Phone
                /// </summary>
        		public string Phone { get; set; }
        	/// <summary>
                /// 	Gets or sets the RealHP
                /// </summary>
        		public Double RealHP { get; set; }
        	/// <summary>
                /// 	Gets or sets the GameHP
                /// </summary>
        		public Double GameHP { get; set; }
 
			/// <summary>
                /// 	Gets or sets the Result
                /// </summary>
        		private ICollection<Result> results;
        		public ICollection<Result> Results
                {
                    get { return results ?? (results = new List<Result>()); }
                    set { results = value; }
                }
        	/// <summary>
                /// 	Gets or sets the User
                /// </summary>
        		private ICollection<User> users;
        		public ICollection<User> Users
                {
                    get { return users ?? (users = new List<User>()); }
                    set { users = value; }
                }
 
    }
}

