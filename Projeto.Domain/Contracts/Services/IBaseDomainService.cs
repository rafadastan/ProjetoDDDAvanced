using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Contracts.Services
{
    public interface IBaseDomainService<TEntity> : IDisposable
        where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        List<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}
