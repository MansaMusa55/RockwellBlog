using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RockwellBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockwellBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext<BlogUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RockwellBlog.Models.Blog> Blog { get; set; }
        public DbSet<RockwellBlog.Models.Post> Posts { get; set; }
        public DbSet<RockwellBlog.Models.Comment> Comment { get; set; }
    }
}
