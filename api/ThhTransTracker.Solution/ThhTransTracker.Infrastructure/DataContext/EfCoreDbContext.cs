namespace ThhTransTracker.Infrastructure.DataContext
{
    public class EfCoreDbContext : DbContext
    {
        public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options) : base(options)
        {
        }

        public DbSet<Route> Routes { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<TruckSize> TruckSizes { get; set; }
        public DbSet<ShipperPrice> ShipperPrices { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorPrice> VendorPrices { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<WaybillDetail> WaybillDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RouteEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ShipperEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TruckSizeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ShipperPriceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new VendorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new VendorPriceEntityConfiguration());
        }
    }
}
