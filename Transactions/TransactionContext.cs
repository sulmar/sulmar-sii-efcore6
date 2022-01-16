using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Models;

namespace Transactions
{
    internal class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }


    }
}
