

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino</CreatedBy>
///<DateCreated>05/07/2014 23:38:26</DateCreated>
///<DateModified>05/07/2014 23:38:26</DateModified>
///<Observations>Tournament repository</Observations>
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
    /// This class contains the main CRUD methods to interact between Database and the 'Tournament' entity 
    /// </summary>
    public class TournamentRepository : IRepository<Tournament>
    {
        /// <summary>
        /// Get a registry by ID
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return a entity type Tournament</returns>
        public Tournament GetById(int Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetTournamentById");
            db.AddInParameter(command, "@Id", DbType.Int32, Id);
            IDataReader dr = db.ExecuteReader(command);
            Tournament tournament = null;
            if(dr.Read())
            {
                tournament = new Tournament();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) tournament.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Year"))) tournament.Year = dr.GetInt32(dr.GetOrdinal("Year"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) tournament.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsFinished"))) tournament.IsFinished = dr.GetBoolean(dr.GetOrdinal("IsFinished"));
	
            }
			dr.Close();
            return tournament;
        }

        /// <summary>
        /// Get all table
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return all Tournaments entities</returns>
        public List<Tournament> GetAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetAllTournament");
            IDataReader dr = db.ExecuteReader(command);
            List<Tournament> tournaments = new List<Tournament>(); 
            while (dr.Read())
            {
                Tournament tournament = new Tournament();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) tournament.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Year"))) tournament.Year = dr.GetInt32(dr.GetOrdinal("Year"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) tournament.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsFinished"))) tournament.IsFinished = dr.GetBoolean(dr.GetOrdinal("IsFinished"));
                tournaments.Add(tournament);
            }
			dr.Close();
            return tournaments;
        }

        /// <summary>
        /// Method to save in Database a Tournament entity 
        /// </summary>
        /// <param name="entity">Tournament</param>
        /// <returns>Return Id entity registered</returns>
        public int Insert(Tournament entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspInsertTournament")) 
            {
							db.AddInParameter(command, "@Year", DbType.Int32, entity.Year);
    			db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
    			db.AddInParameter(command, "@IsFinished", DbType.Boolean, entity.IsFinished);
                db.AddOutParameter(command, "@Id", DbType.Int32, int.MaxValue);
                db.ExecuteNonQuery(command);
                return (int)db.GetParameterValue(command, "@Id");
            }            
        }

        /// <summary>
        /// Method to update in Database a Tournament entity 
        /// </summary>
        /// <param name="entity">Tournament</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Update(Tournament entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspUpdateTournament"))
            {
							db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
    			db.AddInParameter(command, "@Year", DbType.Int32, entity.Year);
    			db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
    			db.AddInParameter(command, "@IsFinished", DbType.Boolean, entity.IsFinished);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in Database a Tournament entity 
        /// </summary>
        /// <param name="entity">Tournament</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Delete(Tournament entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspDeleteTournament"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in a logical-way a Tournament entity 
        /// </summary>
        /// <param name="entity">Tournament</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int LogicalDelete(Tournament entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspLogicalDeleteTournament"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        ///  Get tournaments from database with conditions
        /// </summary>
        /// <param name="whereClause"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<Tournament> GetByWhereClause(string whereClause = null, string orderBy = null)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetTournaments");
            db.AddInParameter(command, "@whereClause", DbType.String, whereClause);
            db.AddInParameter(command, "@OrderByClause", DbType.String, orderBy);
            IDataReader dr = db.ExecuteReader(command);
            List<Tournament> tournaments = new List<Tournament>();
            while (dr.Read())
            {
                Tournament tournament = new Tournament();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) tournament.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Year"))) tournament.Year = dr.GetInt32(dr.GetOrdinal("Year"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) tournament.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsFinished"))) tournament.IsFinished = dr.GetBoolean(dr.GetOrdinal("IsFinished"));
                tournaments.Add(tournament);
            }
			dr.Close();
            return tournaments;
        } 
		
    }
}

