using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        List<TEntity> GetAll();
        List<TEntity> GetAll(Func<TEntity, bool> where);

        TEntity GetById(Guid id);
        TEntity Get(Func<TEntity, bool> where);
        int Count();
        int Count(Func<TEntity, bool> where);
    }
}
