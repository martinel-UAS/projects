

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martínez Palomino</CreatedBy>
///<DateCreated>05/07/2014 19:54:20</DateCreated>
///<DateModified>05/07/2014 19:54:20</DateModified>
///<Observations>Role entity</Observations>
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
    /// 	This class represents a 'Role'
    /// </summary>
    public class Role : BaseEntity
    {
			/// <summary>
                /// 	Gets or sets the RoleName
                /// </summary>
        		public string RoleName { get; set; }
 
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

