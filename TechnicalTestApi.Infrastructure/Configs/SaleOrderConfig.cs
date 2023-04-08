using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TechnicalTestApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechnicalTestApi.Infrastructure.Configs
{
    class SaleOrderConfig : IEntityTypeConfiguration<SaleOrder>
    {
        public void Configure(EntityTypeBuilder<SaleOrder> builder)
        {
            builder.ToTable("sale_orders");
            builder.HasKey(c => c.saleOrderId);

            builder
                .HasMany(saleOrder => saleOrder.saleOrderDetail)
                .WithOne(saleOrderDetail => saleOrderDetail.saleOrder);
        }
    }
}
