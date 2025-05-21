using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tria_2025.Models;

namespace Tria_2025.Data.Mappings
{
    public class MotoSetorMapping : IEntityTypeConfiguration<MotoSetor>
    {
        public void Configure(EntityTypeBuilder<MotoSetor> builder)
        {
            builder.ToTable("Moto_Setor");

            builder.HasKey(f => f.Id);

            builder.Property(ms => ms.Data)
                .IsRequired();

            builder.Property(ms => ms.Fonte)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ms => ms.IdMoto)
                .IsRequired();

            builder.Property(ms => ms.IdSetor)
                .IsRequired();
        }
    }
}
