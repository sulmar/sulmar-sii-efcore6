using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conventions
{
    public static class ModelBuilderExtentions
    {
        public static IEnumerable<IMutableProperty> Properties(this ModelBuilder modelBuilder) => modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties());

        public static IEnumerable<IMutableProperty> Properties<T>(this ModelBuilder modelBuilder) => modelBuilder.Properties().Where(p => p.PropertyInfo?.PropertyType == typeof(T));

        public static void Configure(this IEnumerable<IMutableProperty> properties, Action<IMutableProperty> configuration)
        {
            foreach (IMutableProperty property in properties)
            {
                configuration.Invoke(property);
            }
        }
    }
}
