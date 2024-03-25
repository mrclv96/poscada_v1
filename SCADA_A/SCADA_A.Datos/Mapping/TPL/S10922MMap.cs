using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.TPL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.TPL
{
    public class S10922MMap : IEntityTypeConfiguration<S10922M>
    {
        public void Configure(EntityTypeBuilder<S10922M> builder)
        {
            builder.ToTable("TPL_S10922M")
                .HasKey(p => p.id);
        }
    }
}
