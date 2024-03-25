using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.TPL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.TPL
{
    public class X10376Map : IEntityTypeConfiguration<X10376>
    {
        public void Configure(EntityTypeBuilder<X10376> builder)
        {
            builder.ToTable("TPL_X10376")
                .HasKey(p => p.id);
        }
    }
}
