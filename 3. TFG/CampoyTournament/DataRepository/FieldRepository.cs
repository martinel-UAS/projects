


//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino</CreatedBy>
///<DateCreated>05/07/2014 19:52:27</DateCreated>
///<DateModified>05/07/2014 19:52:27</DateModified>
///<Observations>Field repository</Observations>
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
    /// This class contains the main CRUD methods to interact between Database and the 'Field' entity 
    /// </summary>
    public class FieldRepository : IRepository<Field>
    {
        /// <summary>
        /// Get a registry by ID
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return a entity type Field</returns>
        public Field GetById(int Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetFieldById");
            db.AddInParameter(command, "@Id", DbType.Int32, Id);
            IDataReader dr = db.ExecuteReader(command);
            Field field = null;
            if (dr.Read())
            {
                field = new Field();
                if (!dr.IsDBNull(dr.GetOrdinal("Id"))) field.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) field.Name = dr.GetString(dr.GetOrdinal("Name"));
                if (!dr.IsDBNull(dr.GetOrdinal("Address"))) field.Address = dr.GetString(dr.GetOrdinal("Address"));
                if (!dr.IsDBNull(dr.GetOrdinal("City"))) field.City = dr.GetString(dr.GetOrdinal("City"));
                if (!dr.IsDBNull(dr.GetOrdinal("Province"))) field.Province = dr.GetString(dr.GetOrdinal("Province"));
                if (!dr.IsDBNull(dr.GetOrdinal("Web"))) field.Web = dr.GetString(dr.GetOrdinal("Web"));
                if (!dr.IsDBNull(dr.GetOrdinal("Email"))) field.Email = dr.GetString(dr.GetOrdinal("Email"));
                if (!dr.IsDBNull(dr.GetOrdinal("Phone"))) field.Phone = dr.GetString(dr.GetOrdinal("Phone"));
                if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) field.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));

            }
            dr.Close();
            return field;
        }

        /// <summary>
        /// Get all table
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return all Fields entities</returns>
        public List<Field> GetAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetAllField");
            IDataReader dr = db.ExecuteReader(command);
            List<Field> fields = new List<Field>();
            while (dr.Read())
            {
                Field field = new Field();
                if (!dr.IsDBNull(dr.GetOrdinal("Id"))) field.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) field.Name = dr.GetString(dr.GetOrdinal("Name"));
                if (!dr.IsDBNull(dr.GetOrdinal("Address"))) field.Address = dr.GetString(dr.GetOrdinal("Address"));
                if (!dr.IsDBNull(dr.GetOrdinal("City"))) field.City = dr.GetString(dr.GetOrdinal("City"));
                if (!dr.IsDBNull(dr.GetOrdinal("Province"))) field.Province = dr.GetString(dr.GetOrdinal("Province"));
                if (!dr.IsDBNull(dr.GetOrdinal("Web"))) field.Web = dr.GetString(dr.GetOrdinal("Web"));
                if (!dr.IsDBNull(dr.GetOrdinal("Email"))) field.Email = dr.GetString(dr.GetOrdinal("Email"));
                if (!dr.IsDBNull(dr.GetOrdinal("Phone"))) field.Phone = dr.GetString(dr.GetOrdinal("Phone"));
                if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) field.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
                fields.Add(field);
            }
            dr.Close();
            return fields;
        }

        /// <summary>
        /// Method to save in Database a Field entity 
        /// </summary>
        /// <param name="entity">Field</param>
        /// <returns>Return Id entity registered</returns>
        public int Insert(Field entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspInsertField"))
            {
                db.AddInParameter(command, "@Name", DbType.String, entity.Name);
                db.AddInParameter(command, "@Address", DbType.String, entity.Address);
                db.AddInParameter(command, "@City", DbType.String, entity.City);
                db.AddInParameter(command, "@Province", DbType.String, entity.Province);
                db.AddInParameter(command, "@Web", DbType.String, entity.Web);
                db.AddInParameter(command, "@Email", DbType.String, entity.Email);
                db.AddInParameter(command, "@Phone", DbType.String, entity.Phone);
                db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
                db.AddOutParameter(command, "@Id", DbType.Int32, int.MaxValue);
                db.ExecuteNonQuery(command);
                return (int)db.GetParameterValue(command, "@Id");
            }
        }

        /// <summary>
        /// Method to update in Database a Field entity 
        /// </summary>
        /// <param name="entity">Field</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Update(Field entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspUpdateField"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                db.AddInParameter(command, "@Name", DbType.String, entity.Name);
                db.AddInParameter(command, "@Address", DbType.String, entity.Address);
                db.AddInParameter(command, "@City", DbType.String, entity.City);
                db.AddInParameter(command, "@Province", DbType.String, entity.Province);
                db.AddInParameter(command, "@Web", DbType.String, entity.Web);
                db.AddInParameter(command, "@Email", DbType.String, entity.Email);
                db.AddInParameter(command, "@Phone", DbType.String, entity.Phone);
                db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in Database a Field entity 
        /// </summary>
        /// <param name="entity">Field</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Delete(Field entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspDeleteField"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in a logical-way a Field entity 
        /// </summary>
        /// <param name="entity">Field</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int LogicalDelete(Field entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspLogicalDeleteField"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        ///  Get fields from database with conditions
        /// </summary>
        /// <param name="whereClause"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<Field> GetByWhereClause(string whereClause = null, string orderBy = null)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetFields");
            db.AddInParameter(command, "@whereClause", DbType.String, whereClause);
            db.AddInParameter(command, "@OrderByClause", DbType.String, orderBy);
            IDataReader dr = db.ExecuteReader(command);
            List<Field> fields = new List<Field>();
            while (dr.Read())
            {
                Field field = new Field();
                if (!dr.IsDBNull(dr.GetOrdinal("Id"))) field.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) field.Name = dr.GetString(dr.GetOrdinal("Name"));
                if (!dr.IsDBNull(dr.GetOrdinal("Address"))) field.Address = dr.GetString(dr.GetOrdinal("Address"));
                if (!dr.IsDBNull(dr.GetOrdinal("City"))) field.City = dr.GetString(dr.GetOrdinal("City"));
                if (!dr.IsDBNull(dr.GetOrdinal("Province"))) field.Province = dr.GetString(dr.GetOrdinal("Province"));
                if (!dr.IsDBNull(dr.GetOrdinal("Web"))) field.Web = dr.GetString(dr.GetOrdinal("Web"));
                if (!dr.IsDBNull(dr.GetOrdinal("Email"))) field.Email = dr.GetString(dr.GetOrdinal("Email"));
                if (!dr.IsDBNull(dr.GetOrdinal("Phone"))) field.Phone = dr.GetString(dr.GetOrdinal("Phone"));
                if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) field.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
                fields.Add(field);
            }
            dr.Close();
            return fields;
        }

    }
}

