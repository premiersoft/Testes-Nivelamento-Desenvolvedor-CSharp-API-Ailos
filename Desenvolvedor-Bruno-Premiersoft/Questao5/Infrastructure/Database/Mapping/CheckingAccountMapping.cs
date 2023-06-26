using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.Mapping
{
    public class CheckingAccountMapping : IEntityTypeConfiguration<CheckingAccount>
    {
        public void Configure(EntityTypeBuilder<CheckingAccount> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(c => c.Id)
               .HasColumnName("idcontacorrente")
               .IsRequired();

            builder.Property(c => c.Number)
                .HasColumnName("numero")
                .IsRequired();


            builder.Property(c => c.Name)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(c => c.IsActive)
               .HasColumnName("ativo")
               .HasDefaultValue(true)
               .IsRequired();

            builder.ToTable("contacorrente");
        }
    }
}