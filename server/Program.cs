using AssetCheckoutSystem.Extensions;
using AssetCheckoutSystem.Models.Repositories;
using AssetCheckoutSystem.Repositories;
using AssetCheckoutSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithSerialization();

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
