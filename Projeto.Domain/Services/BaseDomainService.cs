using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Services
{
    public class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class
    {
        private readonly IBaseRepository<TEntity> baseRepository;

        public BaseDomainService(IBaseRepository<TEntity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public virtual void Create(TEntity entity)
        {
            baseRepository.Create(entity);
        }

        public virtual void Update(TEntity entity)
        {
            baseRepository.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            baseRepository.Delete(entity);
        }

        public virtual List<TEntity> GetAll()
        {
            return baseRepository.GetAll();
        }

        public virtual TEntity GetById(Guid id)
        {
            return baseRepository.GetById(id);
        }

        public void Dispose()
        {
            baseRepository.Dispose();
        }
    }
}
