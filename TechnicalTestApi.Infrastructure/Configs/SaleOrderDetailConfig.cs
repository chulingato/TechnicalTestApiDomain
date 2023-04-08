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
    class SaleOrderDetailConfig : IEntityTypeConfiguration<SaleOrderDetail>
    {
        public void Configure(EntityTypeBuilder<SaleOrderDetail> builder)
        {
            builder.ToTable("saleorder_detail");
            builder.HasKey(c => new { c.productId, c.saleOrderId });

            builder
                .HasOne(orderDetail => orderDetail.product)
                .WithMany(product => product.saleOrderDetail);

            builder
                .HasOne(orderDetail => orderDetail.saleOrder)
                .WithMany(order =>  order.saleOrderDetail);

        }
    }
}
