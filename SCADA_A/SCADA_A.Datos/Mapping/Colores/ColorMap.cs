using Microsoft.EntityFrameworkCore;
using SCADA_A.Entidades.Colores;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.Colores
{
    public class ColorMap : IEntityTypeConfiguration<Color>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Color")
                .HasKey(c => c.CodigoColor);
            builder.Property(c => c.Nombre)
                .HasMaxLength(50);
            builder.Property(c => c.RGBHex)
                .HasMaxLength(6);
        }
    }
}
