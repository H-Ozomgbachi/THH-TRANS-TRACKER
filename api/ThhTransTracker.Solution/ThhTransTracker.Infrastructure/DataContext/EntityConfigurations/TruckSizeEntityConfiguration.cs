namespace ThhTransTracker.Infrastructure.DataContext.EntityConfigurations
{
    public class TruckSizeEntityConfiguration : IEntityTypeConfiguration<TruckSize>
    {
        public void Configure(EntityTypeBuilder<TruckSize> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasDefaultValue(Guid.NewGuid());
            builder.Property(x => x.Size).IsRequired().HasMaxLength(3);
            builder.Property(x => x.Unit).IsRequired().HasMaxLength(10);
        }
    }
}
