using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ThhTransTracker.API.Extensions
{
    public static class ServiceConfigurationExtensions
    {
        public static void ConfigureDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<IShipperRepository, ShipperRepository>();
            services.AddScoped<IShipperService, ShipperService>();
            services.AddScoped<ITruckSizeRepository, TruckSizeRepository>();
            services.AddScoped<ITruckSizeService, TruckSizeService>();
            services.AddScoped<IShipperPriceRepository, ShipperPriceRepository>();
            services.AddScoped<IShipperPriceService, ShipperPriceService>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IVendorPriceRepository, VendorPriceRepository>();
            services.AddScoped<IVendorPriceService, VendorPriceService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUtilityRepository, UtilityRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "THH-Trans-Tracker API", Version = "v1" });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Enter a valid JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer"
                        },
                        new List<string>()
                    }
                });
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
            services.AddHttpClient("FileServer", c =>
            {
                c.BaseAddress = new Uri(config["AppSettings:FileServerBaseUrl"]);
            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                }
            });
            services.AddHttpClient("TheHaulageHub", c =>
            {
                c.BaseAddress = new Uri(config["AppSettings:TheHaulageHubBaseUrl"]);
            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                }
            });
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
            services.AddOptions<AppSettings>().Bind(config.GetSection("AppSettings"));
        }

        public static void ConfigureJwtAccess(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtToken:SigningKey"])),
                        LifetimeValidator = LifetimeValidator
                    };
                });
        }
        private static bool LifetimeValidator(DateTime? notBefore,
           DateTime? expires,
           SecurityToken securityToken,
           TokenValidationParameters validationParameters)
        {
            return expires != null && expires > DateTime.UtcNow;
        }
    }
}
