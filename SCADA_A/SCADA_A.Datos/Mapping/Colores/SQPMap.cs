using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.Colores;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.Colores
{
    public class SQPMap : IEntityTypeConfiguration<SQP>
    {
        public void Configure(EntityTypeBuilder<SQP> builder)
        {
            builder.ToTable("sqp")
                .HasKey(a => a.idSQP);
        }
    }
}
