using Microsoft.EntityFrameworkCore;
using VehicleTelemetryApi.Background;
using VehicleTelemetryApi.Data;
using VehicleTelemetryApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TelemetryDbContext>(options =>
    options.UseInMemoryDatabase("TelemetryDb"));

builder.Services.AddScoped<ITelemetryService, TelemetryService>();

builder.Services.AddHostedService<TelemetryBackgroundService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---- CORS Setup ----
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// ---- Middleware ----
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(MyAllowSpecificOrigins); // Apply CORS policy

app.MapControllers();

app.Run();
