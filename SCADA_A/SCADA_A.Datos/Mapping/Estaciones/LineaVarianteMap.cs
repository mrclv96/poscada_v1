using Microsoft.EntityFrameworkCore;
using SCADA_A.Entidades.Estaciones;
using System;

namespace SCADA_A.Datos.Mapping.Estaciones
{
    internal class LineaVarianteMap : IEntityTypeConfiguration<LineaVariante>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LineaVariante> builder)
        {
            builder.ToTable("lineavariante")
                .HasKey(a => a.idLineaVariante);
        }
    }
}
