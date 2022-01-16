using Interceptors.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interceptors
{
    public class InterceptorsContext : DbContext
    {
        public InterceptorsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }


    }
}
