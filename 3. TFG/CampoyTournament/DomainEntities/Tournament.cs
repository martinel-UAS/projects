

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martínez Palomino</CreatedBy>
///<DateCreated>05/07/2014 19:54:20</DateCreated>
///<DateModified>05/07/2014 19:54:20</DateModified>
///<Observations>Tournament entity</Observations>
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
    /// 	This class represents a 'Tournament'
    /// </summary>
    public class Tournament : BaseEntity
    {
        /// <summary>
        /// 	Gets or sets the Year
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 	Gets or sets the IsFinished
        /// </summary>
        public bool IsFinished { get; set; }

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

