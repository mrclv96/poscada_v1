using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.TPL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.TPL
{
    internal class S10921MMap : IEntityTypeConfiguration<S10921M>
    {
        public void Configure(EntityTypeBuilder<S10921M> builder)
        {
            builder.ToTable("TPL_S10921M")
                .HasKey(p => p.id);
        }
    }
}
