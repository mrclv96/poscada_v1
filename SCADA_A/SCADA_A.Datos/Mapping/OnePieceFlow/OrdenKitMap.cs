using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.OnePieceFlow;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.OnePieceFlow
{
    internal class OrdenKitMap : IEntityTypeConfiguration<OrdenKit>
    {
        public void Configure(EntityTypeBuilder<OrdenKit> builder)
        {
            builder.ToTable("ordenkit")
                .HasKey(k => k.idOrdenKit);
        }
    }
}
