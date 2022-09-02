using System;
using System.Collections;
using Company.DataAccess.Store;
using Company.Repository.Repositories;

namespace Company.Repository.UnitOfWorks
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly CompanyContext _context;
        private Hashtable _repositories;
        public UnitOfWork(CompanyContext context)
        {
            _context = context;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var reposiotryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, reposiotryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }
    }
}