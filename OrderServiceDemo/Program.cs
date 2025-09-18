using Steeltoe.Configuration.ConfigServer;    // Config Server support
using Steeltoe.Management.Endpoint;           // Core actuator framework
using Steeltoe.Management.Endpoint.Actuators.All;
using Steeltoe.Management.Endpoint.Actuators.Health;
using Steeltoe.Management.Endpoint.Actuators.Refresh;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1) Add Config Server provider BEFORE build so its values become part of IConfiguration
builder.Configuration.AddConfigServer(); // Steeltoe provider uses "spring:cloud:config:*" keys

// 2) Add controllers
builder.Services.AddControllers();
// 3) Bind a POCO to a config section and use IOptionsMonitor for runtime updates
builder.Services.Configure<FeatureFlags>(builder.Configuration.GetSection("FeatureFlags"));


// 4) Add Steeltoe actuators (recommended: AddAllActuators() in docs; here we add refresh + health)
builder.Services.AddRefreshActuator();         // enables /actuator/refresh
builder.Services.AddHealthActuator();          // enables /actuator/health // let's plug grfana

builder.Services.AddAllActuators(true);//////////////////////////////////////////////////////////questionable
// (alternatively you can use builder.AddAllActuators() depending on Steeltoe version)

// Build app
var app = builder.Build();
// Add all Steeltoe actuators


// Map controllers and actuators
app.MapControllers();
app.Run();

public class FeatureFlags
{
    public bool UseNewCheckout { get; set; } = false;
}

