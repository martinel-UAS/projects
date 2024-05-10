

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino</CreatedBy>
///<DateCreated>05/07/2014 23:38:26</DateCreated>
///<DateModified>05/07/2014 23:38:26</DateModified>
///<Observations>Result repository</Observations>
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
    /// This class contains the main CRUD methods to interact between Database and the 'Result' entity 
    /// </summary>
    public class ResultRepository : IRepository<Result>
    {
        /// <summary>
        /// Get a registry by ID
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return a entity type Result</returns>
        public Result GetById(int Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetResultById");
            db.AddInParameter(command, "@Id", DbType.Int32, Id);
            IDataReader dr = db.ExecuteReader(command);
            Result result = null;
            if(dr.Read())
            {
                result = new Result();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) result.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("HoleId"))) result.HoleId = dr.GetInt32(dr.GetOrdinal("HoleId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("MatchId"))) result.MatchId = dr.GetInt32(dr.GetOrdinal("MatchId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("PlayerId"))) result.PlayerId = dr.GetInt32(dr.GetOrdinal("PlayerId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Strikes"))) result.Strikes = dr.GetInt32(dr.GetOrdinal("Strikes"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Handicap"))) result.Handicap = dr.GetDouble(dr.GetOrdinal("Handicap"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) result.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
	
            }
			dr.Close();
            return result;
        }

        /// <summary>
        /// Get all table
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return all Results entities</returns>
        public List<Result> GetAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetAllResult");
            IDataReader dr = db.ExecuteReader(command);
            List<Result> results = new List<Result>(); 
            while (dr.Read())
            {
                Result result = new Result();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) result.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("HoleId"))) result.HoleId = dr.GetInt32(dr.GetOrdinal("HoleId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("MatchId"))) result.MatchId = dr.GetInt32(dr.GetOrdinal("MatchId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("PlayerId"))) result.PlayerId = dr.GetInt32(dr.GetOrdinal("PlayerId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Strikes"))) result.Strikes = dr.GetInt32(dr.GetOrdinal("Strikes"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Handicap"))) result.Handicap = dr.GetDouble(dr.GetOrdinal("Handicap"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) result.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
                results.Add(result);
            }
			dr.Close();
            return results;
        }

        /// <summary>
        /// Method to save in Database a Result entity 
        /// </summary>
        /// <param name="entity">Result</param>
        /// <returns>Return Id entity registered</returns>
        public int Insert(Result entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspInsertResult")) 
            {
							db.AddInParameter(command, "@HoleId", DbType.Int32, entity.HoleId);
    			db.AddInParameter(command, "@MatchId", DbType.Int32, entity.MatchId);
    			db.AddInParameter(command, "@PlayerId", DbType.Int32, entity.PlayerId);
    			db.AddInParameter(command, "@Strikes", DbType.Int32, entity.Strikes);
    			db.AddInParameter(command, "@Handicap", DbType.Double, entity.Handicap);
    			db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
                db.AddOutParameter(command, "@Id", DbType.Int32, int.MaxValue);
                db.ExecuteNonQuery(command);
                return (int)db.GetParameterValue(command, "@Id");
            }            
        }

        /// <summary>
        /// Method to update in Database a Result entity 
        /// </summary>
        /// <param name="entity">Result</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Update(Result entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspUpdateResult"))
            {
							db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
    			db.AddInParameter(command, "@HoleId", DbType.Int32, entity.HoleId);
    			db.AddInParameter(command, "@MatchId", DbType.Int32, entity.MatchId);
    			db.AddInParameter(command, "@PlayerId", DbType.Int32, entity.PlayerId);
    			db.AddInParameter(command, "@Strikes", DbType.Int32, entity.Strikes);
    			db.AddInParameter(command, "@Handicap", DbType.Double, entity.Handicap);
    			db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in Database a Result entity 
        /// </summary>
        /// <param name="entity">Result</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Delete(Result entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspDeleteResult"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in a logical-way a Result entity 
        /// </summary>
        /// <param name="entity">Result</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int LogicalDelete(Result entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspLogicalDeleteResult"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        ///  Get results from database with conditions
        /// </summary>
        /// <param name="whereClause"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<Result> GetByWhereClause(string whereClause = null, string orderBy = null)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetResults");
            db.AddInParameter(command, "@whereClause", DbType.String, whereClause);
            db.AddInParameter(command, "@OrderByClause", DbType.String, orderBy);
            IDataReader dr = db.ExecuteReader(command);
            List<Result> results = new List<Result>();
            while (dr.Read())
            {
                Result result = new Result();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) result.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("HoleId"))) result.HoleId = dr.GetInt32(dr.GetOrdinal("HoleId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("MatchId"))) result.MatchId = dr.GetInt32(dr.GetOrdinal("MatchId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("PlayerId"))) result.PlayerId = dr.GetInt32(dr.GetOrdinal("PlayerId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Strikes"))) result.Strikes = dr.GetInt32(dr.GetOrdinal("Strikes"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Handicap"))) result.Handicap = dr.GetDouble(dr.GetOrdinal("Handicap"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) result.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
                results.Add(result);
            }
			dr.Close();
            return results;
        } 
		
    }
}

