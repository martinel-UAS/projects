

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martínez Palomino</CreatedBy>
///<DateCreated>05/07/2014 19:54:21</DateCreated>
///<DateModified>05/07/2014 19:54:21</DateModified>
///<Observations>User entity</Observations>
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
    /// 	This class represents a 'User'
    /// </summary>
    public class User : BaseEntity
    {
			/// <summary>
                /// 	Gets or sets the Name
                /// </summary>
        		public string Name { get; set; }
        	/// <summary>
                /// 	Gets or sets the Surname
                /// </summary>
        		public string Surname { get; set; }
        	/// <summary>
                /// 	Gets or sets the Email
                /// </summary>
        		public string Email { get; set; }
        	/// <summary>
                /// 	Gets or sets the Password
                /// </summary>
        		public string Password { get; set; }
        	/// <summary>
                /// 	Gets or sets the RoleId
                /// </summary>
        		public int RoleId { get; set; }
        	/// <summary>
                /// 	Gets or sets the PlayerId
                /// </summary>
        		public int PlayerId { get; set; }
 
		 
    }
}

