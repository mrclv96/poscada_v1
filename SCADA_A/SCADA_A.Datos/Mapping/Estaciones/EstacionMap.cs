using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.Estaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.Estaciones
{
    public class EstacionMap : IEntityTypeConfiguration<Estacion>
    {
        public void Configure(EntityTypeBuilder<Estacion> builder)
        {
            builder.ToTable("estacion")
                .HasKey(a => a.idEstacion);
        }
    }
}
