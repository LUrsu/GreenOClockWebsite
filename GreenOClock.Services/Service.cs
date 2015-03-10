using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace GreenOClock.Services
{
    public interface IService<TEntity>
    {
        IQueryable<TEntity> All();
        TEntity ByKey(Func<TEntity, bool> predicate);
        TEntity Save(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<DbEntityValidationResult> Validate();
    }

    public abstract class Service<TEntity, TDbContext> : IService<TEntity>
        where TEntity : class
        where TDbContext : DbContext, new()
    {
        protected Service()
        {
            Entities = new TDbContext();
        }

        protected TDbContext Entities { get; private set; }

        #region IService<TEntity> Members

        public IQueryable<TEntity> All()
        {
            return Entities.Set<TEntity>();
        }

        public TEntity ByKey(Func<TEntity, bool> predicate)
        {
            return Entities.Set<TEntity>().FirstOrDefault(predicate);
        }
        
        public TEntity Save(TEntity entity)
        {
            List<DbEntityValidationResult> validatationErrors = Entities.GetValidationErrors().ToList();
            if (validatationErrors.Count() > 0)
                throw new ValidateException(validatationErrors);

            if (Entities.Entry(entity).State == EntityState.Added)
                Entities.Set<TEntity>().Add(entity);
            else
                Entities.Set<TEntity>().Attach(entity);

            Entities.SaveChanges();
            Entities.Entry(entity).Reload();
            return entity;
        }

        

        public void Delete(TEntity entity)
        {
            Entities.Set<TEntity>().Remove(entity);
            Entities.SaveChanges();
        }

        public IEnumerable<DbEntityValidationResult> Validate()
        {
            return Entities.GetValidationErrors();
        }

        #endregion
    }
}
