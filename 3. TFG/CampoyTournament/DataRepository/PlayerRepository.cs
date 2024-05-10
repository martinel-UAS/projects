

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino</CreatedBy>
///<DateCreated>05/07/2014 19:52:31</DateCreated>
///<DateModified>05/07/2014 19:52:31</DateModified>
///<Observations>Player repository</Observations>
//************************************************************
//************************************************************
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DomainEntities;

namespace DataRepository
{
    /// <summary>
    /// This class contains the main CRUD methods to interact between Database and the 'Player' entity 
    /// </summary>
    public class PlayerRepository : IRepository<Player>
    {
        /// <summary>
        /// Get a registry by ID
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return a entity type Player</returns>
        public Player GetById(int Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetPlayerById");
            db.AddInParameter(command, "@Id", DbType.Int32, Id);
            IDataReader dr = db.ExecuteReader(command);
            Player player = null;
            if (dr.Read())
            {
                player = new Player();
                if (!dr.IsDBNull(dr.GetOrdinal("Id"))) player.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                if (!dr.IsDBNull(dr.GetOrdinal("License"))) player.License = dr.GetString(dr.GetOrdinal("License"));
                if (!dr.IsDBNull(dr.GetOrdinal("Alias"))) player.Alias = dr.GetString(dr.GetOrdinal("Alias"));
                if (!dr.IsDBNull(dr.GetOrdinal("Phone"))) player.Phone = dr.GetString(dr.GetOrdinal("Phone"));
                if (!dr.IsDBNull(dr.GetOrdinal("RealHP"))) player.RealHP = dr.GetDouble(dr.GetOrdinal("RealHP"));
                if (!dr.IsDBNull(dr.GetOrdinal("GameHP"))) player.GameHP = dr.GetDouble(dr.GetOrdinal("GameHP"));
                if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) player.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));

            }
            dr.Close();
            return player;
        }

        /// <summary>
        /// Get all table
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return all Players entities</returns>
        public List<Player> GetAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetAllPlayer");
            IDataReader dr = db.ExecuteReader(command);
            List<Player> players = new List<Player>();
            while (dr.Read())
            {
                Player player = new Player();
                if (!dr.IsDBNull(dr.GetOrdinal("Id"))) player.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                if (!dr.IsDBNull(dr.GetOrdinal("License"))) player.License = dr.GetString(dr.GetOrdinal("License"));
                if (!dr.IsDBNull(dr.GetOrdinal("Alias"))) player.Alias = dr.GetString(dr.GetOrdinal("Alias"));
                if (!dr.IsDBNull(dr.GetOrdinal("Phone"))) player.Phone = dr.GetString(dr.GetOrdinal("Phone"));
                if (!dr.IsDBNull(dr.GetOrdinal("RealHP"))) player.RealHP = dr.GetDouble(dr.GetOrdinal("RealHP"));
                if (!dr.IsDBNull(dr.GetOrdinal("GameHP"))) player.GameHP = dr.GetDouble(dr.GetOrdinal("GameHP"));
                if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) player.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
                players.Add(player);
            }
            dr.Close();
            return players;
        }

        /// <summary>
        /// Method to save in Database a Player entity 
        /// </summary>
        /// <param name="entity">Player</param>
        /// <returns>Return Id entity registered</returns>
        public int Insert(Player entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspInsertPlayer"))
            {
                db.AddInParameter(command, "@License", DbType.String, entity.License);
                db.AddInParameter(command, "@Alias", DbType.String, entity.Alias);
                db.AddInParameter(command, "@Phone", DbType.String, entity.Phone);
                db.AddInParameter(command, "@RealHP", DbType.Double, entity.RealHP);
                db.AddInParameter(command, "@GameHP", DbType.Double, entity.GameHP);
                db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
                db.AddOutParameter(command, "@Id", DbType.Int32, int.MaxValue);
                db.ExecuteNonQuery(command);
                return (int)db.GetParameterValue(command, "@Id");
            }
        }

        /// <summary>
        /// Method to update in Database a Player entity 
        /// </summary>
        /// <param name="entity">Player</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Update(Player entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspUpdatePlayer"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                db.AddInParameter(command, "@License", DbType.String, entity.License);
                db.AddInParameter(command, "@Alias", DbType.String, entity.Alias);
                db.AddInParameter(command, "@Phone", DbType.String, entity.Phone);
                db.AddInParameter(command, "@RealHP", DbType.Double, entity.RealHP);
                db.AddInParameter(command, "@GameHP", DbType.Double, entity.GameHP);
                db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in Database a Player entity 
        /// </summary>
        /// <param name="entity">Player</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Delete(Player entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspDeletePlayer"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in a logical-way a Player entity 
        /// </summary>
        /// <param name="entity">Player</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int LogicalDelete(Player entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspLogicalDeletePlayer"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        ///  Get players from database with conditions
        /// </summary>
        /// <param name="whereClause"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<Player> GetByWhereClause(string whereClause = null, string orderBy = null)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetPlayers");
            db.AddInParameter(command, "@whereClause", DbType.String, whereClause);
            db.AddInParameter(command, "@OrderByClause", DbType.String, orderBy);
            IDataReader dr = db.ExecuteReader(command);
            List<Player> players = new List<Player>();
            while (dr.Read())
            {
                Player player = new Player();
                if (!dr.IsDBNull(dr.GetOrdinal("Id"))) player.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                if (!dr.IsDBNull(dr.GetOrdinal("License"))) player.License = dr.GetString(dr.GetOrdinal("License"));
                if (!dr.IsDBNull(dr.GetOrdinal("Alias"))) player.Alias = dr.GetString(dr.GetOrdinal("Alias"));
                if (!dr.IsDBNull(dr.GetOrdinal("Phone"))) player.Phone = dr.GetString(dr.GetOrdinal("Phone"));
                if (!dr.IsDBNull(dr.GetOrdinal("RealHP"))) player.RealHP = dr.GetDouble(dr.GetOrdinal("RealHP"));
                if (!dr.IsDBNull(dr.GetOrdinal("GameHP"))) player.GameHP = dr.GetDouble(dr.GetOrdinal("GameHP"));
                if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) player.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
                players.Add(player);
            }
            dr.Close();
            return players;
        }

    }
}

