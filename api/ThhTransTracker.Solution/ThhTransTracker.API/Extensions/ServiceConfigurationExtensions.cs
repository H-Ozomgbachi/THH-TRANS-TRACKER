namespace ThhTransTracker.API.Extensions
{
    public static class ServiceConfigurationExtensions
    {
        public static void ConfigureDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IRouteService, RouteService>();
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "THH-Trans-Tracker API", Version = "v1" });
            });
        }
        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("api-version"));
            });
        }
        public static void ConfigureHttpClient(this IServiceCollection services, IConfiguration config)
        {

        }
        public static void ConfigureHealthChecks(this IServiceCollection services, IConfiguration config)
        {
            services.AddHealthChecks()
                .AddSqlServer(config["AppSettings:DbConnection"]);
        }
        public static void ConfigureOthers(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(typeof(RouteMappers).Assembly);
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CreateRouteDtoValidator>();

            services.AddDbContext<EfCoreDbContext>(options => options.UseSqlServer(config["AppSettings:DbConnection"]));
        }
    }
}
