using System.Collections.Generic;
using Entities.Configuration;

// using Entities.Configuration;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
              base.OnModelCreating(modelBuilder);
              modelBuilder.ApplyConfiguration(new RoleConfiguration());
 
        }
        public DbSet<ScrappedData> ScrappedData { get; set; }

    }
}
