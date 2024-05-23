using FinancialManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialManager.InfraStructure.Configurations
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Agency).HasMaxLength(20);
            builder.Property(x => x.AccountNumber).HasMaxLength(20);
            builder.Property(x => x.AccountBalance).IsRequired();

            builder.HasMany(x => x.Registers)
                   .WithOne(r => r.Bank)
                   .HasForeignKey(r => r.BankId);
        }
    }
}