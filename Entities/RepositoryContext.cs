using System.Collections.Generic;
// using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder){
        //     modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        //     modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        // }
        public DbSet<ScrappedData> ScrappedData { get; set; }

    }
}
