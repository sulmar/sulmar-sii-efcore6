using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interceptors.Models
{
    public abstract class Base
    {

    }

    public abstract class BaseEntity : Base
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }

    public class Customer : BaseEntity
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
    }
}
