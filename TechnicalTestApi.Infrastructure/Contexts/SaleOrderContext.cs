using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TechnicalTestApi.Domain;
using TechnicalTestApi.Infrastructure.Configs;

namespace TechnicalTestApi.Infrastructure.Contexts
{
    public class SaleOrderContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<SaleOrderDetail> SaleOrdersDetail { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Data Source=localhost;Initial Catalog=ApiDb;User ID=sa;Password=Admin123@; Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new SaleOrderConfig());
            modelBuilder.ApplyConfiguration(new SaleOrderDetailConfig());
        }
    }
}
