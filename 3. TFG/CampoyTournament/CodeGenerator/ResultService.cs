

//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino  </CreatedBy>
///<DateCreated>05/07/2014 19:58:12</DateCreated>
///<DateModified>05/07/2014 19:58:12</DateModified>
///<Observations>Result Service</Observations>
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
    /// Result service
    /// </summary>
    public class ResultService
    {
		#region Properties
        private readonly IRepository<Result> resultRepository;
        #endregion
		#region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="resultRepository"></param>
        public ResultService()
        {
			this.resultRepository = (ResultRepository)InstanceService.CreateInstanceRepository("ResultRepository");
        }
        #endregion

		#region Methods
        /// <summary>
        /// Gets a result
        /// </summary>
        /// <param name="resultId">Result identifier</param>
        /// <returns>Result</returns>
        public  Result GetResultById(int resultId)
        {
            if (resultId == 0)
                return null;
            return resultRepository.GetById(resultId);
        }

		/// <summary>
        /// GetAll result 
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Result> GetAllResult()
        {
            List<Result> results = resultRepository.GetAll();
            return results;
        }

        /// <summary>
        /// Inserts result
        /// </summary>
        /// <param name="result">Result</param>
        public int InsertResult(Result result)
        {
            if (result == null)
                throw new ArgumentNullException("result");
            return resultRepository.Insert(result);
        }

        /// <summary>
        /// Updates the result
        /// </summary>
        /// <param name="result">Result</param>
        public int UpdateResult(Result result)
        {
            if (result == null)
                throw new ArgumentNullException("result");
            return resultRepository.Update(result);
        }

        /// <summary>
        /// Delete result
        /// </summary>
        /// <param name="result">Result</param>
        public int DeleteResult(Result result)
        {
            if (result == null)
                throw new ArgumentNullException("result");
            return resultRepository.Delete(result);
        }

        /// <summary>
        /// Logical Delete
        /// </summary>
        /// <param name="result">Result</param>
        public int LogicalDeleteResult(Result result)
        {
            if (result == null)
                throw new ArgumentNullException("result");
            result.IsDeleted = true;
            return resultRepository.LogicalDelete(result);
        }

		/// <summary>
        /// Get all result ordered by
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Result> GetAllResultsOrderBy(string orderBy)
        {
            List<Result> results = resultRepository.GetByWhereClause(null, orderBy);
            return results;
        }

		/// <summary>
        /// Get all result ordered by
        /// </summary>
		/// <param name="whereClause">Where Clause</param>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Result> GetAllResultsOrderBy(string whereClause, string orderBy)
        {
            List<Result> results = resultRepository.GetByWhereClause(whereClause, orderBy);
            return results;
        }

        #endregion
		#region Custom Methods
        

        #endregion
    }
}

