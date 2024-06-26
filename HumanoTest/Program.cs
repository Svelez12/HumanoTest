using HealthChecks.UI.Client;
using HumanoTest.Api.ConfigurationServices;
using HumanoTest.Application;
using HumanoTest.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseServices(builder.Configuration);
IoCApplicationRegister.AddRegistration(builder.Services);
IoCInfrastructureRegister.AddRegistration(builder.Services);

builder.Services.AddHealthChecks()
    .AddCheck("HumanoTest API", () => HealthCheckResult.Healthy("HumanoTest check is healthy.")).AddDbContextCheck<HumanoTestDbContext>("HumanoTest Database");

builder.Services.AddHealthChecksUI().AddInMemoryStorage();

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

app.UseHealthChecks("/hc", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHealthChecksUI(options =>
{
    options.UIPath = "/healthchecks-ui";
    options.ApiPath = "/health-ui-api";
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();