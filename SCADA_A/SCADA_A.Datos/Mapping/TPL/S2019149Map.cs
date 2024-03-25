using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.Produccion;
using SCADA_A.Entidades.TPL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.TPL
{
    public class S2019149Map : IEntityTypeConfiguration<S2019149>
    {
        public void Configure(EntityTypeBuilder<S2019149> builder)
        {
            builder.ToTable("TPL_S2019149")
                .HasKey(p => p.id);
        }
    }
}
