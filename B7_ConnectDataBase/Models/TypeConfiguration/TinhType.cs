using B7_ConnectDataBase.Models.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B7_ConnectDataBase.Models.TypeConfiguration
{
    public class TinhType : IEntityTypeConfiguration<Tinh>
    {
        public void Configure(EntityTypeBuilder<Tinh> builder)
        {
            builder.HasKey(e => e.Idtp)
                    .HasName("PK__Tinh__B87C3A84A3A5F322");

            builder.Property(e => e.Idtp)
                    .HasColumnName("IDTP")
                    .ValueGeneratedNever();

            builder.Property(e => e.NameTp)
                    .HasColumnName("NameTP")
                    .HasMaxLength(300);
        }
    }
}
