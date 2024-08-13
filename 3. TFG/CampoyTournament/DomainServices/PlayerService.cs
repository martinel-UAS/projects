

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino  </CreatedBy>
///<DateCreated>05/07/2014 19:58:12</DateCreated>
///<DateModified>05/07/2014 19:58:12</DateModified>
///<Observations>Player Service</Observations>
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
    /// Player service
    /// </summary>
    public class PlayerService
    {
        #region Properties
        private readonly IRepository<Player> playerRepository;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="playerRepository"></param>
        public PlayerService()
        {
            this.playerRepository = (PlayerRepository)InstanceService.CreateInstanceRepository("PlayerRepository");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets a player
        /// </summary>
        /// <param name="playerId">Player identifier</param>
        /// <returns>Player</returns>
        public Player GetPlayerById(int playerId)
        {
            if (playerId == 0)
                return null;
            return playerRepository.GetById(playerId);
        }

        /// <summary>
        /// GetAll player 
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Player> GetAllPlayer()
        {
            List<Player> players = playerRepository.GetAll();
            return players;
        }

        /// <summary>
        /// Inserts player
        /// </summary>
        /// <param name="player">Player</param>
        public int InsertPlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException("player");
            return playerRepository.Insert(player);
        }

        /// <summary>
        /// Updates the player
        /// </summary>
        /// <param name="player">Player</param>
        public int UpdatePlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException("player");
            return playerRepository.Update(player);
        }

        /// <summary>
        /// Delete player
        /// </summary>
        /// <param name="player">Player</param>
        public int DeletePlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException("player");
            return playerRepository.Delete(player);
        }

        /// <summary>
        /// Logical Delete
        /// </summary>
        /// <param name="player">Player</param>
        public int LogicalDeletePlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException("player");
            player.IsDeleted = true;
            return playerRepository.LogicalDelete(player);
        }

        /// <summary>
        /// Get all player ordered by
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Player> GetAllPlayersOrderBy(string orderBy)
        {
            List<Player> players = playerRepository.GetByWhereClause(null, orderBy);
            return players;
        }

        /// <summary>
        /// Get all player ordered by
        /// </summary>
        /// <param name="whereClause">Where Clause</param>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Player> GetAllPlayersOrderBy(string whereClause, string orderBy)
        {
            List<Player> players = playerRepository.GetByWhereClause(whereClause, orderBy);
            return players;
        }

        #endregion
        #region Custom Methods

        /// <summary>
        /// Gets a player deleted or not
        /// </summary>
        /// <param name="playerId">Player identifier</param>
        /// <returns>Player</returns>
        public Player GetPlayerByIdDeletedOrNot(int playerId)
        {
            if (playerId == 0)
                return null;
            string whereClause = "Id =" + playerId + " AND (IsDeleted = 0 OR IsDeleted = 1)";
            return playerRepository.GetByWhereClause(whereClause, "Id").FirstOrDefault();
        }

        #endregion
    }
}

