using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.Estaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.Estaciones
{
    public class LineaMap : IEntityTypeConfiguration<Linea>
    {
        public void Configure(EntityTypeBuilder<Linea> builder)
        {
            builder.ToTable("linea")
                .HasKey(a => a.idLinea);
        }
    }
}
