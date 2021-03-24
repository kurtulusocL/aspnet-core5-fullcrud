using EfCoreCrud.Core.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Core.Business.EntityFramework
{
    public class EfBaseRepository<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Create(TEntity model)
        {
            using (TContext context = new TContext())
            {
                var addEntity = context.Entry(model);
                addEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity model)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(model);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(int? id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public void Update(TEntity model)
        {
            using (TContext context = new TContext())
            {               
                var updatedEntity = context.Entry(model);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}