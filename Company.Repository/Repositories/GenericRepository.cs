using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Company.DataAccess.Store;
using Microsoft.EntityFrameworkCore;

namespace Company.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CompanyContext _context;
        public GenericRepository(CompanyContext context)
        {
            _context = context;
        }       
        public T GetById(Int64 id)
        {
            return _context.Set<T>().Find(id);
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();            
        }
        public IReadOnlyList<T> ListAll()
        {
            return _context.Set<T>().ToList();               
        }
        public void Add(T entity)
        {
           _context.Set<T>().Add(entity);
           _context.Entry(entity).State = EntityState.Added;
        }
        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.Entry(entity).State = EntityState.Deleted;
        }
        public void TruncateTable(string tableName)
        {
        
        }
        public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
           return _context.Set<T>().Where(predicate);
        }
        public IReadOnlyList<T> ExecuteStored(string query, params object[] parameters)
        {
            var r = _context.Set<T>().FromSqlRaw(query, parameters);
            return r.ToList();
        }
    }
}