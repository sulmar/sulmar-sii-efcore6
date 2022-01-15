using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
    }

   
    public class IdentityUser
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class ApplicationUser : IdentityUser
    {
        public string AccountNumber { get; set; }
    }
    
}
