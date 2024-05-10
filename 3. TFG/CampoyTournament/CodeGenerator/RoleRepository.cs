

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino</CreatedBy>
///<DateCreated>05/07/2014 23:38:26</DateCreated>
///<DateModified>05/07/2014 23:38:26</DateModified>
///<Observations>Role repository</Observations>
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
    /// This class contains the main CRUD methods to interact between Database and the 'Role' entity 
    /// </summary>
    public class RoleRepository : IRepository<Role>
    {
        /// <summary>
        /// Get a registry by ID
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return a entity type Role</returns>
        public Role GetById(int Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetRoleById");
            db.AddInParameter(command, "@Id", DbType.Int32, Id);
            IDataReader dr = db.ExecuteReader(command);
            Role role = null;
            if(dr.Read())
            {
                role = new Role();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) role.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("RoleName"))) role.RoleName = dr.GetString(dr.GetOrdinal("RoleName"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) role.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
	
            }
			dr.Close();
            return role;
        }

        /// <summary>
        /// Get all table
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return all Roles entities</returns>
        public List<Role> GetAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetAllRole");
            IDataReader dr = db.ExecuteReader(command);
            List<Role> roles = new List<Role>(); 
            while (dr.Read())
            {
                Role role = new Role();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) role.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("RoleName"))) role.RoleName = dr.GetString(dr.GetOrdinal("RoleName"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) role.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
                roles.Add(role);
            }
			dr.Close();
            return roles;
        }

        /// <summary>
        /// Method to save in Database a Role entity 
        /// </summary>
        /// <param name="entity">Role</param>
        /// <returns>Return Id entity registered</returns>
        public int Insert(Role entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspInsertRole")) 
            {
							db.AddInParameter(command, "@RoleName", DbType.String, entity.RoleName);
    			db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
                db.AddOutParameter(command, "@Id", DbType.Int32, int.MaxValue);
                db.ExecuteNonQuery(command);
                return (int)db.GetParameterValue(command, "@Id");
            }            
        }

        /// <summary>
        /// Method to update in Database a Role entity 
        /// </summary>
        /// <param name="entity">Role</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Update(Role entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspUpdateRole"))
            {
							db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
    			db.AddInParameter(command, "@RoleName", DbType.String, entity.RoleName);
    			db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in Database a Role entity 
        /// </summary>
        /// <param name="entity">Role</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Delete(Role entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspDeleteRole"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in a logical-way a Role entity 
        /// </summary>
        /// <param name="entity">Role</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int LogicalDelete(Role entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspLogicalDeleteRole"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        ///  Get roles from database with conditions
        /// </summary>
        /// <param name="whereClause"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<Role> GetByWhereClause(string whereClause = null, string orderBy = null)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetRoles");
            db.AddInParameter(command, "@whereClause", DbType.String, whereClause);
            db.AddInParameter(command, "@OrderByClause", DbType.String, orderBy);
            IDataReader dr = db.ExecuteReader(command);
            List<Role> roles = new List<Role>();
            while (dr.Read())
            {
                Role role = new Role();
							if (!dr.IsDBNull(dr.GetOrdinal("Id"))) role.Id = dr.GetInt32(dr.GetOrdinal("Id"));
    			if (!dr.IsDBNull(dr.GetOrdinal("RoleName"))) role.RoleName = dr.GetString(dr.GetOrdinal("RoleName"));
    			if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) role.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
                roles.Add(role);
            }
			dr.Close();
            return roles;
        } 
		
    }
}

