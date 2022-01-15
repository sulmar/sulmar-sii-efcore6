using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    public class CustomersContextFactory : IDesignTimeDbContextFactory<CustomersContext>
    {
        public CustomersContext CreateDbContext(string[] args)
        {
            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=CustomersDb";

            var options = new DbContextOptionsBuilder<CustomersContext>()
                .UseSqlServer(connectionString).Options;

            return new CustomersContext(options);
        }
    }
}
