

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino</CreatedBy>
///<DateCreated>05/07/2014 23:38:25</DateCreated>
///<DateModified>05/07/2014 23:38:25</DateModified>
///<Observations>Match repository</Observations>
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
    /// This class contains the main CRUD methods to interact between Database and the 'Match' entity 
    /// </summary>
    public class MatchRepository : IRepository<Match>
    {
        /// <summary>
        /// Get a registry by ID
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return a entity type Match</returns>
        public Match GetById(int Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetMatchById");
            db.AddInParameter(command, "@Id", DbType.Int32, Id);
            IDataReader dr = db.ExecuteReader(command);
            Match match = null;
            if(dr.Read())
            {
                match = new Match();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) match.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("TournamentId"))) match.TournamentId = dr.GetInt32(dr.GetOrdinal("TournamentId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("FieldId"))) match.FieldId = dr.GetInt32(dr.GetOrdinal("FieldId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Date"))) match.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) match.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsTournament"))) match.IsTournament = dr.GetBoolean(dr.GetOrdinal("IsTournament"));
	
            }
			dr.Close();
            return match;
        }

        /// <summary>
        /// Get all table
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return all Matchs entities</returns>
        public List<Match> GetAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetAllMatch");
            IDataReader dr = db.ExecuteReader(command);
            List<Match> matchs = new List<Match>(); 
            while (dr.Read())
            {
                Match match = new Match();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) match.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("TournamentId"))) match.TournamentId = dr.GetInt32(dr.GetOrdinal("TournamentId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("FieldId"))) match.FieldId = dr.GetInt32(dr.GetOrdinal("FieldId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Date"))) match.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) match.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsTournament"))) match.IsTournament = dr.GetBoolean(dr.GetOrdinal("IsTournament"));
                matchs.Add(match);
            }
			dr.Close();
            return matchs;
        }

        /// <summary>
        /// Method to save in Database a Match entity 
        /// </summary>
        /// <param name="entity">Match</param>
        /// <returns>Return Id entity registered</returns>
        public int Insert(Match entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspInsertMatch")) 
            {
							db.AddInParameter(command, "@TournamentId", DbType.Int32, entity.TournamentId);
    			db.AddInParameter(command, "@FieldId", DbType.Int32, entity.FieldId);
    			db.AddInParameter(command, "@Date", DbType.DateTime, entity.Date);
    			db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
    			db.AddInParameter(command, "@IsTournament", DbType.Boolean, entity.IsTournament);
                db.AddOutParameter(command, "@Id", DbType.Int32, int.MaxValue);
                db.ExecuteNonQuery(command);
                return (int)db.GetParameterValue(command, "@Id");
            }            
        }

        /// <summary>
        /// Method to update in Database a Match entity 
        /// </summary>
        /// <param name="entity">Match</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Update(Match entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspUpdateMatch"))
            {
							db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
    			db.AddInParameter(command, "@TournamentId", DbType.Int32, entity.TournamentId);
    			db.AddInParameter(command, "@FieldId", DbType.Int32, entity.FieldId);
    			db.AddInParameter(command, "@Date", DbType.DateTime, entity.Date);
    			db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
    			db.AddInParameter(command, "@IsTournament", DbType.Boolean, entity.IsTournament);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in Database a Match entity 
        /// </summary>
        /// <param name="entity">Match</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Delete(Match entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspDeleteMatch"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in a logical-way a Match entity 
        /// </summary>
        /// <param name="entity">Match</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int LogicalDelete(Match entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspLogicalDeleteMatch"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        ///  Get matchs from database with conditions
        /// </summary>
        /// <param name="whereClause"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<Match> GetByWhereClause(string whereClause = null, string orderBy = null)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetMatchs");
            db.AddInParameter(command, "@whereClause", DbType.String, whereClause);
            db.AddInParameter(command, "@OrderByClause", DbType.String, orderBy);
            IDataReader dr = db.ExecuteReader(command);
            List<Match> matchs = new List<Match>();
            while (dr.Read())
            {
                Match match = new Match();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) match.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("TournamentId"))) match.TournamentId = dr.GetInt32(dr.GetOrdinal("TournamentId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("FieldId"))) match.FieldId = dr.GetInt32(dr.GetOrdinal("FieldId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Date"))) match.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) match.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsTournament"))) match.IsTournament = dr.GetBoolean(dr.GetOrdinal("IsTournament"));
                matchs.Add(match);
            }
			dr.Close();
            return matchs;
        } 
		
    }
}

