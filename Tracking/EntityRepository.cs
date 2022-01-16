using ChangeTracking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTracking
{
    public interface IEntityRepository<T>
    {
        
    }

    public class DbEntityRepository<T> : IEntityRepository<T>
        where T : BaseEntity, new()
    {
        protected readonly ChangeTrackingContext context;

        protected DbSet<T> dbset => context.Set<T>();

        public DbEntityRepository(ChangeTrackingContext context)
        {
            this.context = context;
        }

        public void Remove(int id)
        {
            dbset.Remove(id);
            context.SaveChanges();
        }
    }

    public class ProductRepository : DbEntityRepository<Product>
    {
        public ProductRepository(ChangeTrackingContext context) : base(context)
        {
        }

        
    }

    public static class DbSetExtensions
    {
        public static void Remove<TEntity, TValue>(this DbSet<TEntity> dbset, TValue id)
            where TEntity : class, new()
            where TValue : struct

        {
            var context = dbset.GetService<ICurrentDbContext>().Context;

            var keyName = GetKeyName<TEntity>(context);

            TEntity entity = new();

            entity.GetType().GetProperty(keyName).SetValue(entity, id);

            context.Remove(entity);
        }

        private static string GetKeyName<TEntity>(DbContext context)
        {
            var keyName = context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey()
                .Properties
                .Select(x => x.Name)
                .Single();

            return keyName;
        }
    }
}
