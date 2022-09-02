using System;
using Company.Repository.Repositories;

namespace Company.Repository.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        int Complete();
    }
}