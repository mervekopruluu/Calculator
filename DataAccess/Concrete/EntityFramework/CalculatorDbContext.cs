using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataAccess.Concrete.EntityFramework
{
    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext()
        {
            //Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
        }
       
        public DbSet<Calculator> Calculators { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<CalculatorDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}