namespace ThhTransTracker.Infrastructure.DataContext
{
    public class EfCoreDbContext : DbContext
    {
        public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options) : base(options)
        {
        }

        public DbSet<Route> Routes { get; set; }
        public DbSet<Shipper> Shippers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RouteEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ShipperEntityConfiguration());
        }
    }
}
