using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(Int64 id);
        IReadOnlyList<T> ListAll();
        Task<IReadOnlyList<T>> ListAllAsync();
        void Add(T enitity);
        void Update(T entity);
        void Delete(T entity);
        void TruncateTable(string tableName);
         IQueryable<T> Query(Expression<Func<T, bool>> predicate);  
        IReadOnlyList<T> ExecuteStored(string query, params object[] parameters);
    }
}