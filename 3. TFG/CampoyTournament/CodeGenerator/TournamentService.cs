

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino  </CreatedBy>
///<DateCreated>05/07/2014 19:58:12</DateCreated>
///<DateModified>05/07/2014 19:58:12</DateModified>
///<Observations>Tournament Service</Observations>
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
    /// Tournament service
    /// </summary>
    public class TournamentService
    {
		#region Properties
        private readonly IRepository<Tournament> tournamentRepository;
        #endregion
		#region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="tournamentRepository"></param>
        public TournamentService()
        {
			this.tournamentRepository = (TournamentRepository)InstanceService.CreateInstanceRepository("TournamentRepository");
        }
        #endregion

		#region Methods
        /// <summary>
        /// Gets a tournament
        /// </summary>
        /// <param name="tournamentId">Tournament identifier</param>
        /// <returns>Tournament</returns>
        public  Tournament GetTournamentById(int tournamentId)
        {
            if (tournamentId == 0)
                return null;
            return tournamentRepository.GetById(tournamentId);
        }

		/// <summary>
        /// GetAll tournament 
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Tournament> GetAllTournament()
        {
            List<Tournament> tournaments = tournamentRepository.GetAll();
            return tournaments;
        }

        /// <summary>
        /// Inserts tournament
        /// </summary>
        /// <param name="tournament">Tournament</param>
        public int InsertTournament(Tournament tournament)
        {
            if (tournament == null)
                throw new ArgumentNullException("tournament");
            return tournamentRepository.Insert(tournament);
        }

        /// <summary>
        /// Updates the tournament
        /// </summary>
        /// <param name="tournament">Tournament</param>
        public int UpdateTournament(Tournament tournament)
        {
            if (tournament == null)
                throw new ArgumentNullException("tournament");
            return tournamentRepository.Update(tournament);
        }

        /// <summary>
        /// Delete tournament
        /// </summary>
        /// <param name="tournament">Tournament</param>
        public int DeleteTournament(Tournament tournament)
        {
            if (tournament == null)
                throw new ArgumentNullException("tournament");
            return tournamentRepository.Delete(tournament);
        }

        /// <summary>
        /// Logical Delete
        /// </summary>
        /// <param name="tournament">Tournament</param>
        public int LogicalDeleteTournament(Tournament tournament)
        {
            if (tournament == null)
                throw new ArgumentNullException("tournament");
            tournament.IsDeleted = true;
            return tournamentRepository.LogicalDelete(tournament);
        }

		/// <summary>
        /// Get all tournament ordered by
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Tournament> GetAllTournamentsOrderBy(string orderBy)
        {
            List<Tournament> tournaments = tournamentRepository.GetByWhereClause(null, orderBy);
            return tournaments;
        }

		/// <summary>
        /// Get all tournament ordered by
        /// </summary>
		/// <param name="whereClause">Where Clause</param>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Tournament> GetAllTournamentsOrderBy(string whereClause, string orderBy)
        {
            List<Tournament> tournaments = tournamentRepository.GetByWhereClause(whereClause, orderBy);
            return tournaments;
        }

        #endregion
		#region Custom Methods
        

        #endregion
    }
}

