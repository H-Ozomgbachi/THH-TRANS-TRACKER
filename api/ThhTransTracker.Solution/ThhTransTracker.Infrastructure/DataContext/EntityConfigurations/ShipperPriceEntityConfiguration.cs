namespace ThhTransTracker.Infrastructure.DataContext.EntityConfigurations
{
    public class ShipperPriceEntityConfiguration : IEntityTypeConfiguration<ShipperPrice>
    {
        public void Configure(EntityTypeBuilder<ShipperPrice> builder)
        {
            builder.Property(x => x.Origin).IsRequired().HasMaxLength(256);
            builder.Property(x => x.DestinationCity).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Price).HasPrecision(10, 2);
        }
    }
}