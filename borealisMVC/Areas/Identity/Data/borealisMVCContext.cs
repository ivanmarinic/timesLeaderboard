using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using borealisMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace borealisMVC.Data
{
    public class borealisMVCContext : IdentityDbContext<IdentityUser>
    {
        public borealisMVCContext(DbContextOptions<borealisMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Time> Times { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
