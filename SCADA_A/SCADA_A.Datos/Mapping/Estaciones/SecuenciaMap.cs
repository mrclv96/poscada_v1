﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.Estaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.Estaciones
{
    public class SecuenciaMap : IEntityTypeConfiguration<Secuencia>
    {
        public void Configure(EntityTypeBuilder<Secuencia> builder)
        {
            builder.ToTable("secuencia")
                .HasKey(a => a.idSecuencia);
        }
    }
}
