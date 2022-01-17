using CompiledModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiledModels
{
    public class CompiledModelsContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CompiledModelsContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // options.UseModel(CompiledModels.CompiledModelsContextModel.Instance);
        }
    }
}
