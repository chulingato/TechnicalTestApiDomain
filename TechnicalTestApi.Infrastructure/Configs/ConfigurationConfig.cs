using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestApi.Domain;

namespace TechnicalTestApi.Infrastructure.Data.Configs
{
    public class ConfigurationConfig : IEntityTypeConfiguration<Configuration>
    {
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.ToTable("configurations");
            builder.HasKey(c => c.configurationId);
            builder.HasData(
                new Configuration
                {
                    configurationId = 1,
                    key = "IVA",
                    value = "13"
                });
        }
    }
}
