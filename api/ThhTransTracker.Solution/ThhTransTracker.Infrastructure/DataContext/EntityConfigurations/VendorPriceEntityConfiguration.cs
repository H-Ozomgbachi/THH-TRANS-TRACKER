namespace ThhTransTracker.Infrastructure.DataContext.EntityConfigurations
{
    public class VendorPriceEntityConfiguration : IEntityTypeConfiguration<VendorPrice>
    {
        public void Configure(EntityTypeBuilder<VendorPrice> builder)
        {
            builder.Property(x => x.Origin).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DestinationCity).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Price).HasPrecision(10, 2);

            builder.HasOne("Vendor");
        }
    }
}
