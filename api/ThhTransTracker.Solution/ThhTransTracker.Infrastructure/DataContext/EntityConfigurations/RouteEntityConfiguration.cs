namespace ThhTransTracker.Infrastructure.DataContext.EntityConfigurations
{
    public class RouteEntityConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
            builder.Property(x => x.OriginState).IsRequired().HasMaxLength(100);
            builder.Property(x => x.OriginCity).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DestinationState).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DestinationCity).IsRequired().HasMaxLength(100);
            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
