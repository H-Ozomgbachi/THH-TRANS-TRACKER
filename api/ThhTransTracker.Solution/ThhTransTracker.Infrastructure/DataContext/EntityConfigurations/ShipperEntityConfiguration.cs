namespace ThhTransTracker.Infrastructure.DataContext.EntityConfigurations
{
    public class ShipperEntityConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasDefaultValue(Guid.NewGuid());
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(256);
            builder.Property(x => x.ContactEmail).IsRequired().HasMaxLength(256);
            builder.Property(x => x.ContactPhone).IsRequired().HasMaxLength(256);

            builder.HasMany("ShipperPrices").WithOne("Shipper").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
