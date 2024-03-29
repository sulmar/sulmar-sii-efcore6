﻿using Microsoft.EntityFrameworkCore;
using RelatedData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatedData
{
    internal class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Navigation(p => p.Owner).AutoInclude();

            modelBuilder.Entity<Blog>()
                .Navigation(p => p.Posts).AutoInclude();

        }



    }
}
