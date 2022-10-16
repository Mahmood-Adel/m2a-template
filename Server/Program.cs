using Infrastructure;
using Server.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddHttpContextAccessor();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddInfrastructureServices(builder.Configuration);


//Configurations
Config.ConfigureLocalization(services);
Config.ConfigurePolicies(services);
Config.ConfigureServices(services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRequestLocalization();

app.UseAuthentication();
// Localize strings.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();