using Microsoft.EntityFrameworkCore;
using QueryUpdateMapping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryUpdateMapping
{

    public class PostContext : DbContext
    {     

        public PostContext(DbContextOptions options) : base(options)
        {
        }

       
    }
}
