using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.Productos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.Productos
{
    public class FasciaMap : IEntityTypeConfiguration<Fascia>
    {
        public void Configure(EntityTypeBuilder<Fascia> builder)
        {
            builder.ToTable("fascia")
                .HasKey(a => a.idFascia);
        }
    }
}
