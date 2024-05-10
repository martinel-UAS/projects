

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino</CreatedBy>
///<DateCreated>05/07/2014 23:38:25</DateCreated>
///<DateModified>05/07/2014 23:38:25</DateModified>
///<Observations>Hole repository</Observations>
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
    /// This class contains the main CRUD methods to interact between Database and the 'Hole' entity 
    /// </summary>
    public class HoleRepository : IRepository<Hole>
    {
        /// <summary>
        /// Get a registry by ID
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return a entity type Hole</returns>
        public Hole GetById(int Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetHoleById");
            db.AddInParameter(command, "@Id", DbType.Int32, Id);
            IDataReader dr = db.ExecuteReader(command);
            Hole hole = null;
            if(dr.Read())
            {
                hole = new Hole();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) hole.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("FieldId"))) hole.FieldId = dr.GetInt32(dr.GetOrdinal("FieldId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Handicap"))) hole.Handicap = dr.GetInt32(dr.GetOrdinal("Handicap"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Distance"))) hole.Distance = dr.GetInt32(dr.GetOrdinal("Distance"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) hole.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
	
            }
			dr.Close();
            return hole;
        }

        /// <summary>
        /// Get all table
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return all Holes entities</returns>
        public List<Hole> GetAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetAllHole");
            IDataReader dr = db.ExecuteReader(command);
            List<Hole> holes = new List<Hole>(); 
            while (dr.Read())
            {
                Hole hole = new Hole();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) hole.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("FieldId"))) hole.FieldId = dr.GetInt32(dr.GetOrdinal("FieldId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Handicap"))) hole.Handicap = dr.GetInt32(dr.GetOrdinal("Handicap"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Distance"))) hole.Distance = dr.GetInt32(dr.GetOrdinal("Distance"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) hole.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
                holes.Add(hole);
            }
			dr.Close();
            return holes;
        }

        /// <summary>
        /// Method to save in Database a Hole entity 
        /// </summary>
        /// <param name="entity">Hole</param>
        /// <returns>Return Id entity registered</returns>
        public int Insert(Hole entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspInsertHole")) 
            {
							db.AddInParameter(command, "@FieldId", DbType.Int32, entity.FieldId);
    			db.AddInParameter(command, "@Handicap", DbType.Int32, entity.Handicap);
    			db.AddInParameter(command, "@Distance", DbType.Int32, entity.Distance);
    			db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
                db.AddOutParameter(command, "@Id", DbType.Int32, int.MaxValue);
                db.ExecuteNonQuery(command);
                return (int)db.GetParameterValue(command, "@Id");
            }            
        }

        /// <summary>
        /// Method to update in Database a Hole entity 
        /// </summary>
        /// <param name="entity">Hole</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Update(Hole entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspUpdateHole"))
            {
							db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
    			db.AddInParameter(command, "@FieldId", DbType.Int32, entity.FieldId);
    			db.AddInParameter(command, "@Handicap", DbType.Int32, entity.Handicap);
    			db.AddInParameter(command, "@Distance", DbType.Int32, entity.Distance);
    			db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in Database a Hole entity 
        /// </summary>
        /// <param name="entity">Hole</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Delete(Hole entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspDeleteHole"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in a logical-way a Hole entity 
        /// </summary>
        /// <param name="entity">Hole</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int LogicalDelete(Hole entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspLogicalDeleteHole"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        ///  Get holes from database with conditions
        /// </summary>
        /// <param name="whereClause"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<Hole> GetByWhereClause(string whereClause = null, string orderBy = null)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetHoles");
            db.AddInParameter(command, "@whereClause", DbType.String, whereClause);
            db.AddInParameter(command, "@OrderByClause", DbType.String, orderBy);
            IDataReader dr = db.ExecuteReader(command);
            List<Hole> holes = new List<Hole>();
            while (dr.Read())
            {
                Hole hole = new Hole();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) hole.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("FieldId"))) hole.FieldId = dr.GetInt32(dr.GetOrdinal("FieldId"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Handicap"))) hole.Handicap = dr.GetInt32(dr.GetOrdinal("Handicap"));
    			if (!dr.IsDBNull(dr.GetOrdinal("Distance"))) hole.Distance = dr.GetInt32(dr.GetOrdinal("Distance"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) hole.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
                holes.Add(hole);
            }
			dr.Close();
            return holes;
        } 
		
    }
}

