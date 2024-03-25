using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.OEE;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.OEE
{
    public class ProductCostVMap : IEntityTypeConfiguration<ProductCostV>
    {
        public void Configure(EntityTypeBuilder<ProductCostV> builder)
        {
            builder.ToView("ProductCostV")
                .HasKey(p => p.MaterialId);
        }
    }
}
