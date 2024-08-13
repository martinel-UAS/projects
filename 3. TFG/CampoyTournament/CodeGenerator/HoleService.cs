

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino  </CreatedBy>
///<DateCreated>05/07/2014 19:58:12</DateCreated>
///<DateModified>05/07/2014 19:58:12</DateModified>
///<Observations>Hole Service</Observations>
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
    /// Hole service
    /// </summary>
    public class HoleService
    {
		#region Properties
        private readonly IRepository<Hole> holeRepository;
        #endregion
		#region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="holeRepository"></param>
        public HoleService()
        {
			this.holeRepository = (HoleRepository)InstanceService.CreateInstanceRepository("HoleRepository");
        }
        #endregion

		#region Methods
        /// <summary>
        /// Gets a hole
        /// </summary>
        /// <param name="holeId">Hole identifier</param>
        /// <returns>Hole</returns>
        public  Hole GetHoleById(int holeId)
        {
            if (holeId == 0)
                return null;
            return holeRepository.GetById(holeId);
        }

		/// <summary>
        /// GetAll hole 
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Hole> GetAllHole()
        {
            List<Hole> holes = holeRepository.GetAll();
            return holes;
        }

        /// <summary>
        /// Inserts hole
        /// </summary>
        /// <param name="hole">Hole</param>
        public int InsertHole(Hole hole)
        {
            if (hole == null)
                throw new ArgumentNullException("hole");
            return holeRepository.Insert(hole);
        }

        /// <summary>
        /// Updates the hole
        /// </summary>
        /// <param name="hole">Hole</param>
        public int UpdateHole(Hole hole)
        {
            if (hole == null)
                throw new ArgumentNullException("hole");
            return holeRepository.Update(hole);
        }

        /// <summary>
        /// Delete hole
        /// </summary>
        /// <param name="hole">Hole</param>
        public int DeleteHole(Hole hole)
        {
            if (hole == null)
                throw new ArgumentNullException("hole");
            return holeRepository.Delete(hole);
        }

        /// <summary>
        /// Logical Delete
        /// </summary>
        /// <param name="hole">Hole</param>
        public int LogicalDeleteHole(Hole hole)
        {
            if (hole == null)
                throw new ArgumentNullException("hole");
            hole.IsDeleted = true;
            return holeRepository.LogicalDelete(hole);
        }

		/// <summary>
        /// Get all hole ordered by
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Hole> GetAllHolesOrderBy(string orderBy)
        {
            List<Hole> holes = holeRepository.GetByWhereClause(null, orderBy);
            return holes;
        }

		/// <summary>
        /// Get all hole ordered by
        /// </summary>
		/// <param name="whereClause">Where Clause</param>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Hole> GetAllHolesOrderBy(string whereClause, string orderBy)
        {
            List<Hole> holes = holeRepository.GetByWhereClause(whereClause, orderBy);
            return holes;
        }

        #endregion
		#region Custom Methods
        

        #endregion
    }
}

