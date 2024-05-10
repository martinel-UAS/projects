

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino  </CreatedBy>
///<DateCreated>05/07/2014 19:58:12</DateCreated>
///<DateModified>05/07/2014 19:58:12</DateModified>
///<Observations>User Service</Observations>
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
    /// User service
    /// </summary>
    public class UserService
    {
		#region Properties
        private readonly IRepository<User> userRepository;
        #endregion
		#region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="userRepository"></param>
        public UserService()
        {
			this.userRepository = (UserRepository)InstanceService.CreateInstanceRepository("UserRepository");
        }
        #endregion

		#region Methods
        /// <summary>
        /// Gets a user
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <returns>User</returns>
        public  User GetUserById(int userId)
        {
            if (userId == 0)
                return null;
            return userRepository.GetById(userId);
        }

		/// <summary>
        /// GetAll user 
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<User> GetAllUser()
        {
            List<User> users = userRepository.GetAll();
            return users;
        }

        /// <summary>
        /// Inserts user
        /// </summary>
        /// <param name="user">User</param>
        public int InsertUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return userRepository.Insert(user);
        }

        /// <summary>
        /// Updates the user
        /// </summary>
        /// <param name="user">User</param>
        public int UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return userRepository.Update(user);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="user">User</param>
        public int DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return userRepository.Delete(user);
        }

        /// <summary>
        /// Logical Delete
        /// </summary>
        /// <param name="user">User</param>
        public int LogicalDeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            user.IsDeleted = true;
            return userRepository.LogicalDelete(user);
        }

		/// <summary>
        /// Get all user ordered by
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<User> GetAllUsersOrderBy(string orderBy)
        {
            List<User> users = userRepository.GetByWhereClause(null, orderBy);
            return users;
        }

		/// <summary>
        /// Get all user ordered by
        /// </summary>
		/// <param name="whereClause">Where Clause</param>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<User> GetAllUsersOrderBy(string whereClause, string orderBy)
        {
            List<User> users = userRepository.GetByWhereClause(whereClause, orderBy);
            return users;
        }

        #endregion
		#region Custom Methods
        

        #endregion
    }
}

