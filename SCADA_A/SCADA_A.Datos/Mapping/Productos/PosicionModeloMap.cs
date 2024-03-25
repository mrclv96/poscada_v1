using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.Productos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.Productos
{
    public class PosicionModeloMap : IEntityTypeConfiguration<PosicionModelo>
    {
        public void Configure(EntityTypeBuilder<PosicionModelo> builder)
        {
            builder.ToTable("posicionmodelo")
                .HasKey(a => a.idPosicionModelo);
        }
    }
}
