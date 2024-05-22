using FinancialManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialManager.InfraStructure.Configurations
{
    public class RegisterConfiguration : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Amount).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Bank)
                   .WithMany(b => b.Registers)
                   .HasForeignKey(x => x.BankId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Category)
                   .WithMany()
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.RegisterType)
                   .WithMany()
                   .HasForeignKey(x => x.RegisterTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}