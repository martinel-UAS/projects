


//************************************************************
//************************************************************
///<Project>CampoyTournament</Project>
///<CreatedBy>Luis Martinez Palomino  </CreatedBy>
///<DateCreated>05/07/2014 19:58:12</DateCreated>
///<DateModified>05/07/2014 19:58:12</DateModified>
///<Observations>Field Service</Observations>
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
    /// Field service
    /// </summary>
    public class FieldService
    {
		#region Properties
        private readonly IRepository<Field> fieldRepository;
        #endregion
		#region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="fieldRepository"></param>
        public FieldService()
        {
			this.fieldRepository = (FieldRepository)InstanceService.CreateInstanceRepository("FieldRepository");
        }
        #endregion

		#region Methods
        /// <summary>
        /// Gets a field
        /// </summary>
        /// <param name="fieldId">Field identifier</param>
        /// <returns>Field</returns>
        public  Field GetFieldById(int fieldId)
        {
            if (fieldId == 0)
                return null;
            return fieldRepository.GetById(fieldId);
        }

		/// <summary>
        /// GetAll field 
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Field> GetAllField()
        {
            List<Field> fields = fieldRepository.GetAll();
            return fields;
        }

        /// <summary>
        /// Inserts field
        /// </summary>
        /// <param name="field">Field</param>
        public int InsertField(Field field)
        {
            if (field == null)
                throw new ArgumentNullException("field");
            return fieldRepository.Insert(field);
        }

        /// <summary>
        /// Updates the field
        /// </summary>
        /// <param name="field">Field</param>
        public int UpdateField(Field field)
        {
            if (field == null)
                throw new ArgumentNullException("field");
            return fieldRepository.Update(field);
        }

        /// <summary>
        /// Delete field
        /// </summary>
        /// <param name="field">Field</param>
        public int DeleteField(Field field)
        {
            if (field == null)
                throw new ArgumentNullException("field");
            return fieldRepository.Delete(field);
        }

        /// <summary>
        /// Logical Delete
        /// </summary>
        /// <param name="field">Field</param>
        public int LogicalDeleteField(Field field)
        {
            if (field == null)
                throw new ArgumentNullException("field");
            field.IsDeleted = true;
            return fieldRepository.LogicalDelete(field);
        }

		/// <summary>
        /// Get all field ordered by
        /// </summary>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Field> GetAllFieldsOrderBy(string orderBy)
        {
            List<Field> fields = fieldRepository.GetByWhereClause(null, orderBy);
            return fields;
        }

		/// <summary>
        /// Get all field ordered by
        /// </summary>
		/// <param name="whereClause">Where Clause</param>
        /// <param name="orderBy">Column name</param>
        /// <returns></returns>
        public List<Field> GetAllFieldsOrderBy(string whereClause, string orderBy)
        {
            List<Field> fields = fieldRepository.GetByWhereClause(whereClause, orderBy);
            return fields;
        }

        #endregion
		#region Custom Methods
        

        #endregion
    }
}

