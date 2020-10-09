using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ENSEKMeterReading.Core.Models;

namespace ENSEKMeterReading.Data.Configurations
{
    public class MeterReadingConfiguration : IEntityTypeConfiguration<MeterReading>
    {
        public void Configure(EntityTypeBuilder<MeterReading> builder)
        {
            builder
                .HasKey(a => a.AccountId);

            //builder
            //    .Property(m => m.AccountId)
            //    . UseIdentityColumn();

            builder
                .Property(m => m.MeterReadingDateTime)
                .IsRequired();

            builder
                .Property(m => m.MeterReadValue)
                .IsRequired().HasMaxLength(5);

            builder
                .ToTable("MeterReading");
        }
    }
}