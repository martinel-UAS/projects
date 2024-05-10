

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino</CreatedBy>
///<DateCreated>05/07/2014 19:52:35</DateCreated>
///<DateModified>05/07/2014 19:52:35</DateModified>
///<Observations>User repository</Observations>
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
    /// This class contains the main CRUD methods to interact between Database and the 'User' entity 
    /// </summary>
    public class UserRepository : IRepository<User>
    {
        /// <summary>
        /// Get a registry by ID
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return a entity type User</returns>
        public User GetById(int Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetUserById");
            db.AddInParameter(command, "@Id", DbType.Int32, Id);
            IDataReader dr = db.ExecuteReader(command);
            User user = null;
            if (dr.Read())
            {
                user = new User();
                if (!dr.IsDBNull(dr.GetOrdinal("Id"))) user.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) user.Name = dr.GetString(dr.GetOrdinal("Name"));
                if (!dr.IsDBNull(dr.GetOrdinal("Surname"))) user.Surname = dr.GetString(dr.GetOrdinal("Surname"));
                if (!dr.IsDBNull(dr.GetOrdinal("Email"))) user.Email = dr.GetString(dr.GetOrdinal("Email"));
                if (!dr.IsDBNull(dr.GetOrdinal("Password"))) user.Password = dr.GetString(dr.GetOrdinal("Password"));
                if (!dr.IsDBNull(dr.GetOrdinal("RoleId"))) user.RoleId = dr.GetInt32(dr.GetOrdinal("RoleId"));
                if (!dr.IsDBNull(dr.GetOrdinal("PlayerId"))) user.PlayerId = dr.GetInt32(dr.GetOrdinal("PlayerId"));
                if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) user.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));

            }
            dr.Close();
            return user;
        }

        /// <summary>
        /// Get all table
        /// </summary>
        /// <param name="Id">Id entity</param>
        /// <returns>Return all Users entities</returns>
        public List<User> GetAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetAllUser");
            IDataReader dr = db.ExecuteReader(command);
            List<User> users = new List<User>();
            while (dr.Read())
            {
                User user = new User();
                if (!dr.IsDBNull(dr.GetOrdinal("Id"))) user.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) user.Name = dr.GetString(dr.GetOrdinal("Name"));
                if (!dr.IsDBNull(dr.GetOrdinal("Surname"))) user.Surname = dr.GetString(dr.GetOrdinal("Surname"));
                if (!dr.IsDBNull(dr.GetOrdinal("Email"))) user.Email = dr.GetString(dr.GetOrdinal("Email"));
                if (!dr.IsDBNull(dr.GetOrdinal("Password"))) user.Password = dr.GetString(dr.GetOrdinal("Password"));
                if (!dr.IsDBNull(dr.GetOrdinal("RoleId"))) user.RoleId = dr.GetInt32(dr.GetOrdinal("RoleId"));
                if (!dr.IsDBNull(dr.GetOrdinal("PlayerId"))) user.PlayerId = dr.GetInt32(dr.GetOrdinal("PlayerId"));
                if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) user.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
                users.Add(user);
            }
            dr.Close();
            return users;
        }

        /// <summary>
        /// Method to save in Database a User entity 
        /// </summary>
        /// <param name="entity">User</param>
        /// <returns>Return Id entity registered</returns>
        public int Insert(User entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspInsertUser"))
            {
                db.AddInParameter(command, "@Name", DbType.String, entity.Name);
                db.AddInParameter(command, "@Surname", DbType.String, entity.Surname);
                db.AddInParameter(command, "@Email", DbType.String, entity.Email);
                db.AddInParameter(command, "@Password", DbType.String, entity.Password);
                db.AddInParameter(command, "@RoleId", DbType.Int32, entity.RoleId);
                db.AddInParameter(command, "@PlayerId", DbType.Int32, entity.PlayerId);
                db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
                db.AddOutParameter(command, "@Id", DbType.Int32, int.MaxValue);
                db.ExecuteNonQuery(command);
                return (int)db.GetParameterValue(command, "@Id");
            }
        }

        /// <summary>
        /// Method to update in Database a User entity 
        /// </summary>
        /// <param name="entity">User</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Update(User entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspUpdateUser"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                db.AddInParameter(command, "@Name", DbType.String, entity.Name);
                db.AddInParameter(command, "@Surname", DbType.String, entity.Surname);
                db.AddInParameter(command, "@Email", DbType.String, entity.Email);
                db.AddInParameter(command, "@Password", DbType.String, entity.Password);
                db.AddInParameter(command, "@RoleId", DbType.Int32, entity.RoleId);
                db.AddInParameter(command, "@PlayerId", DbType.Int32, entity.PlayerId);
                db.AddInParameter(command, "@IsDeleted", DbType.Boolean, entity.IsDeleted);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in Database a User entity 
        /// </summary>
        /// <param name="entity">User</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int Delete(User entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspDeleteUser"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Method to delete in a logical-way a User entity 
        /// </summary>
        /// <param name="entity">User</param>
        /// <returns>Return the number of the rows affeted</returns>
        public int LogicalDelete(User entity)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbCommand command = db.GetStoredProcCommand("uspLogicalDeleteUser"))
            {
                db.AddInParameter(command, "@Id", DbType.Int32, entity.Id);
                return db.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        ///  Get users from database with conditions
        /// </summary>
        /// <param name="whereClause"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<User> GetByWhereClause(string whereClause = null, string orderBy = null)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand command = db.GetStoredProcCommand("uspGetUsers");
            db.AddInParameter(command, "@whereClause", DbType.String, whereClause);
            db.AddInParameter(command, "@OrderByClause", DbType.String, orderBy);
            IDataReader dr = db.ExecuteReader(command);
            List<User> users = new List<User>();
            while (dr.Read())
            {
                User user = new User();
                if (!dr.IsDBNull(dr.GetOrdinal("Id"))) user.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) user.Name = dr.GetString(dr.GetOrdinal("Name"));
                if (!dr.IsDBNull(dr.GetOrdinal("Surname"))) user.Surname = dr.GetString(dr.GetOrdinal("Surname"));
                if (!dr.IsDBNull(dr.GetOrdinal("Email"))) user.Email = dr.GetString(dr.GetOrdinal("Email"));
                if (!dr.IsDBNull(dr.GetOrdinal("Password"))) user.Password = dr.GetString(dr.GetOrdinal("Password"));
                if (!dr.IsDBNull(dr.GetOrdinal("RoleId"))) user.RoleId = dr.GetInt32(dr.GetOrdinal("RoleId"));
                if (!dr.IsDBNull(dr.GetOrdinal("PlayerId"))) user.PlayerId = dr.GetInt32(dr.GetOrdinal("PlayerId"));
                if (!dr.IsDBNull(dr.GetOrdinal("IsDeleted"))) user.IsDeleted = dr.GetBoolean(dr.GetOrdinal("IsDeleted"));
                users.Add(user);
            }
            dr.Close();
            return users;
        }

    }
}

