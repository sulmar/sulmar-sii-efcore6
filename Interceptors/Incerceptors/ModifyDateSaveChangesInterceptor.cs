using Interceptors.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interceptors.Incerceptors
{

    internal class ModifyDateSaveChangesInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            return SetModifiedDate(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            SetModifiedDate(eventData, result);

            return ValueTask.FromResult(result);
        }

        private static InterceptionResult<int> SetModifiedDate(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var modifiedEntities = eventData.Context.ChangeTracker.Entries()
                .Where(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Modified)
                .Select(e => e.Entity)
                .OfType<BaseEntity>();

            foreach (var entity in modifiedEntities)
            {
                entity.ModifiedOn = DateTime.UtcNow;
            }

            return result;
        }
    }
}
