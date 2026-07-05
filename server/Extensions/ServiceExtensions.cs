using AssetCheckoutSystem.Data;
using AssetCheckoutSystem.Models.Entities;
using AssetCheckoutSystem.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.OpenApi.Models;

namespace AssetCheckoutSystem.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var logger = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }).CreateLogger("Authentication");

            string jwtKey = config["JwtKey"]
                                ?? throw new Exception("JwtKey missing from configuration.");

            if (config["AccessTokenExpirationMinutes"] == null)
                logger.LogWarning("AccessTokenExpirationMinutes not configured. Defaulting to 15 minutes.");

            if (config["RefreshTokenExpirationDays"] == null)
                logger.LogWarning("RefreshTokenExpirationDays not configured. Defaulting to 7 days.");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtKey))
                    };

                    // On every request, we want to get the user for validation
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async context =>
                        {
                            var userRepository =
                                context.HttpContext.RequestServices
                                    .GetRequiredService<UserRepository>();

                            Guid userId = context.Principal!.GetUserId();

                            User? user = await userRepository.GetById(userId);

                            if (user == null || !user.IsActive)
                            {
                                context.Fail("User is inactive or does not exist");
                                return;
                            }

                            // Create Claim for most current User Role 
                            var identity = (ClaimsIdentity)context.Principal!.Identity!;

                            identity.AddClaim(
                                new Claim(ClaimTypes.Role, user.Role.ToString()));

                            // Caching user object so endpoints can easily retrieve it
                            // without additional query
                            context.HttpContext.Items["User"] = user;
                        }
                    };
                });

            return services;
        }

        public static IServiceCollection AddRoleAuthorization(this IServiceCollection services)
        {
            services.AddAuthorizationBuilder()
                .AddPolicy("AssetManager+", policy =>
                {
                    policy.RequireAssertion(context =>
                        context.User.IsInRole("AssetManager") ||
                        context.User.IsInRole("Admin"));
                });

            return services;
        }

        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration config,
            IWebHostEnvironment env)
        {
            string? host = config["DB_HOST"];
            string? port = config["DB_PORT"];
            string? database = config["DB_NAME"];
            string? username = config["DB_USER"];
            string? password = config["DB_PASSWORD"];

            string connectionString;

            bool hasEnvVars =
                !string.IsNullOrWhiteSpace(host) &&
                !string.IsNullOrWhiteSpace(port) &&
                !string.IsNullOrWhiteSpace(database) &&
                !string.IsNullOrWhiteSpace(username) &&
                !string.IsNullOrWhiteSpace(password);

            if (hasEnvVars)
            {
                connectionString =
                    $"Server=tcp:{host},{port};" +
                    $"Initial Catalog={database};" +
                    $"Persist Security Info=False;" +
                    $"User ID={username};Password={password};" +
                    $"MultipleActiveResultSets=False;" +
                    $"Encrypt=True;TrustServerCertificate=False;" +
                    $"Connection Timeout=60;";
            }
            else if (env.IsDevelopment())
            {
                connectionString = config.GetConnectionString("DefaultConnection")
                    ?? throw new InvalidOperationException("Missing DefaultConnection in appsettings.Development.json");
            }
            else
            {
                throw new InvalidOperationException(
                    "Production environment requires DB_HOST/DB_PORT/DB_NAME/DB_USER/DB_PASSWORD environment variables");
            }

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure());
            });

            return services;
        }

        public static IServiceCollection AddCustomCors(
            this IServiceCollection services,
            IConfiguration config)
        {
            var logger = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }).CreateLogger("Cors");

            string FrontendURL = config["FrontendURL"] ?? throw new Exception("FrontendURL missing from configuration.");

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(FrontendURL);

                    policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });

            logger.LogInformation($"Cors Enabled for {FrontendURL}");

            return services;
        }
    
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Your-Token\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }

        public static IServiceCollection AddControllersWithSerialization(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    // Ensure all dates are treated/serialized as UTC
                    options.SerializerSettings.DateTimeZoneHandling =
                        Newtonsoft.Json.DateTimeZoneHandling.Utc;

                    // Enforce ISO format
                    options.SerializerSettings.DateFormatHandling =
                        Newtonsoft.Json.DateFormatHandling.IsoDateFormat;

                    // Enforce enums are string and camel-case
                    options.SerializerSettings.Converters.Add(
                        new Newtonsoft.Json.Converters.StringEnumConverter(
                            new Newtonsoft.Json.Serialization.CamelCaseNamingStrategy(),
                            allowIntegerValues: false
                        )
                    );
                });

            return services;
        }
    }
}
