using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainEntities;

namespace DataRepository
{
    public partial interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        List<T> GetAll();
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        int LogicalDelete(T entity);
        List<T> GetByWhereClause(string whereClause = null, string orderBy = null);
    }

}