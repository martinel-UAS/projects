

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino  </CreatedBy>
///<DateCreated>05/07/2014 19:58:12</DateCreated>
///<DateModified>05/07/2014 19:58:12</DateModified>
///<Observations>Match Service</Observations>
//************************************************************
//************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainEntities;
using DataRepository;

namespace DomainServices
{
    /// <summary>
    /// Match service
    /// </summary>
    public class MatchService
    {
        #region Properties
        private readonly IRepository<Match> matchRepository;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="matchRepository"></param>
        public MatchService()
        {
            this.matchRepository = (MatchRepository)InstanceService.CreateInstanceRepository("MatchRepository");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets a match
        /// </summary>
        /// <param name="matchId">Match identifier</param>
        /// <returns>Match</returns>
        public Match GetMatchById(int matchId)
        {
            if (matchId == 0)
                return null;
            return matchRepository.GetById(matchId);
        }

        /// <summary>
        /// GetAll match 
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Match> GetAllMatch()
        {
            List<Match> matchs = matchRepository.GetAll();
            return matchs;
        }

        /// <summary>
        /// Inserts match
        /// </summary>
        /// <param name="match">Match</param>
        public int InsertMatch(Match match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            return matchRepository.Insert(match);
        }

        /// <summary>
        /// Updates the match
        /// </summary>
        /// <param name="match">Match</param>
        public int UpdateMatch(Match match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            return matchRepository.Update(match);
        }

        /// <summary>
        /// Delete match
        /// </summary>
        /// <param name="match">Match</param>
        public int DeleteMatch(Match match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            return matchRepository.Delete(match);
        }

        /// <summary>
        /// Logical Delete
        /// </summary>
        /// <param name="match">Match</param>
        public int LogicalDeleteMatch(Match match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            match.IsDeleted = true;
            return matchRepository.LogicalDelete(match);
        }

        /// <summary>
        /// Get all match ordered by
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Match> GetAllMatchsOrderBy(string orderBy)
        {
            List<Match> matchs = matchRepository.GetByWhereClause(null, orderBy);
            return matchs;
        }

        /// <summary>
        /// Get all match ordered by
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Match> GetAllMatchsOrderBy(string whereClause, string orderBy)
        {
            List<Match> matchs = matchRepository.GetByWhereClause(whereClause, orderBy);
            return matchs;
        }

        #endregion
        #region Custom Methods


        #endregion
    }
}

