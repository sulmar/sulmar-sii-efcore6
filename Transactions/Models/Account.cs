using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public static decimal BalanceLimit = 1200m;

        public override string ToString() => $"{AccountNumber} {Balance:C2}";
    }
}
