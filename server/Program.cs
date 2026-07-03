using AssetManagementSystem.Extensions;
using AssetManagementSystem.Models.Repositories;
using AssetManagementSystem.Repositories;
using AssetManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(
            new Newtonsoft.Json.Converters.StringEnumConverter(
                new Newtonsoft.Json.Serialization.CamelCaseNamingStrategy(),
                allowIntegerValues: false
            )
        );
    });

builder.Services.AddScoped<UserRepository>()
                .AddScoped<AssetRepository>()
                .AddScoped<CheckoutRequestRepository>()
                .AddScoped<TokenService>()
                .AddScoped<CheckoutRequestService>()
                .AddScoped<AssetService>()
                .AddScoped<UserService>();

builder.Services.AddDatabase(builder.Configuration, builder.Environment)
                .AddCustomCors(builder.Configuration)
                .AddJwtAuthentication(builder.Configuration)
                .AddRoleAuthorization()
                .AddSwagger();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.ApplyMigrations();

app.Run();
