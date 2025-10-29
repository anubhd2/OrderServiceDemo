using Steeltoe.Configuration.ConfigServer;    // Config Server support
using Steeltoe.Management.Endpoint;           // Core actuator framework
using Steeltoe.Management.Endpoint.Actuators.All;
using Steeltoe.Management.Endpoint.Actuators.Health;
using Steeltoe.Management.Endpoint.Actuators.Refresh;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddConfigServer();
builder.Services.AddControllers();
builder.Services.Configure<FeatureFlags>(builder.Configuration.GetSection("FeatureFlags"));
builder.Services.AddRefreshActuator();
builder.Services.AddHealthActuator();
builder.Services.AddAllActuators(true);

var app = builder.Build();


app.UseRouting();
app.UseHttpMetrics(); 

app.MapControllers();
app.MapMetrics(); //metrics for Prometheus
app.MapActuators();

app.Run();

public class FeatureFlags
{
    public bool UseNewCheckout { get; set; } = false;
}

