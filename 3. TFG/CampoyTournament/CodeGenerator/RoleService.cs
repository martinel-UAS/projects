

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino  </CreatedBy>
///<DateCreated>05/07/2014 19:58:12</DateCreated>
///<DateModified>05/07/2014 19:58:12</DateModified>
///<Observations>Role Service</Observations>
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
    /// Role service
    /// </summary>
    public class RoleService
    {
		#region Properties
        private readonly IRepository<Role> roleRepository;
        #endregion
		#region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="roleRepository"></param>
        public RoleService()
        {
			this.roleRepository = (RoleRepository)InstanceService.CreateInstanceRepository("RoleRepository");
        }
        #endregion

		#region Methods
        /// <summary>
        /// Gets a role
        /// </summary>
        /// <param name="roleId">Role identifier</param>
        /// <returns>Role</returns>
        public  Role GetRoleById(int roleId)
        {
            if (roleId == 0)
                return null;
            return roleRepository.GetById(roleId);
        }

		/// <summary>
        /// GetAll role 
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Role> GetAllRole()
        {
            List<Role> roles = roleRepository.GetAll();
            return roles;
        }

        /// <summary>
        /// Inserts role
        /// </summary>
        /// <param name="role">Role</param>
        public int InsertRole(Role role)
        {
            if (role == null)
                throw new ArgumentNullException("role");
            return roleRepository.Insert(role);
        }

        /// <summary>
        /// Updates the role
        /// </summary>
        /// <param name="role">Role</param>
        public int UpdateRole(Role role)
        {
            if (role == null)
                throw new ArgumentNullException("role");
            return roleRepository.Update(role);
        }

        /// <summary>
        /// Delete role
        /// </summary>
        /// <param name="role">Role</param>
        public int DeleteRole(Role role)
        {
            if (role == null)
                throw new ArgumentNullException("role");
            return roleRepository.Delete(role);
        }

        /// <summary>
        /// Logical Delete
        /// </summary>
        /// <param name="role">Role</param>
        public int LogicalDeleteRole(Role role)
        {
            if (role == null)
                throw new ArgumentNullException("role");
            role.IsDeleted = true;
            return roleRepository.LogicalDelete(role);
        }

		/// <summary>
        /// Get all role ordered by
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Role> GetAllRolesOrderBy(string orderBy)
        {
            List<Role> roles = roleRepository.GetByWhereClause(null, orderBy);
            return roles;
        }

		/// <summary>
        /// Get all role ordered by
        /// </summary>
		/// <param name="whereClause">Where Clause</param>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Role> GetAllRolesOrderBy(string whereClause, string orderBy)
        {
            List<Role> roles = roleRepository.GetByWhereClause(whereClause, orderBy);
            return roles;
        }

        #endregion
		#region Custom Methods
        

        #endregion
    }
}

