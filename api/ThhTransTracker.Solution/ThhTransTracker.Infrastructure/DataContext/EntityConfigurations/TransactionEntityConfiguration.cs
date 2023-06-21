namespace ThhTransTracker.Infrastructure.DataContext.EntityConfigurations
{
    public class TransactionEntityConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(x => x.ShipperName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.OriginCity).IsRequired().HasMaxLength(256);
            builder.Property(x => x.DestinationCity).IsRequired().HasMaxLength(256);

            builder.HasAlternateKey(x => x.UniqueTransactionCode);

            builder.HasOne("WaybillDetail");
        }
    }
}
