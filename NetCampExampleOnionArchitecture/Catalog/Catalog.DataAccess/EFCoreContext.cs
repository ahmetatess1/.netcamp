using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DataAccess
{
    public class EFCoreContext:DbContext
    {
        public EFCoreContext()
        {
        }

        public EFCoreContext(DbContextOptions<EFCoreContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = @"Server=(localdb)\MSSQLLocalDB;Database=CampDB;Trusted_Connection=True;ConnectRetryCount=0";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
