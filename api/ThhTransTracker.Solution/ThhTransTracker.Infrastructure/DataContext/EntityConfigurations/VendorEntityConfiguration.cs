namespace ThhTransTracker.Infrastructure.DataContext.EntityConfigurations
{
    public class VendorEntityConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.Property(x => x.VendorName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.AccountName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.AccountNumber).IsRequired().HasMaxLength(10);
            builder.Property(x => x.BankName).IsRequired().HasMaxLength(256);

            builder.HasMany("VendorPrices").WithOne("Vendor").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
