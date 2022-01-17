using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiledModels
{
    public class CustomersContextFactory : IDesignTimeDbContextFactory<CompiledModelsContext>
    {
        public CompiledModelsContext CreateDbContext(string[] args)
        {
            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=CompiledModelsDb";

            var options = new DbContextOptionsBuilder<CompiledModelsContext>()
                .UseSqlServer(connectionString).Options;

            return new CompiledModelsContext(options);
        }
    }
}
