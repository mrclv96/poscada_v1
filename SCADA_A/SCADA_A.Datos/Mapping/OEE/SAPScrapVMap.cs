using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.OEE;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.OEE
{
    public class SAPScrapVMap : IEntityTypeConfiguration<SAPScrapV>
    {
        void IEntityTypeConfiguration<SAPScrapV>.Configure(EntityTypeBuilder<SAPScrapV> builder)
        {
            builder.ToView("SAPScrapV")
                .HasKey(s => new { s.Mat_Doc, s.Material, s.Quantity_in_UnE });
        }
    }
}
