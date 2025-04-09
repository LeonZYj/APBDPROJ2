using DeviceManager.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var devices = new List<Device>
{
    new SmartWatch("SW-1", "Apple Watch SE2", true, "27%"),
    new PC("P-1", "LinuxPC", false, "Linux Mint"),
    new PC("P-2", "ThinkPad T440", false),
    new EmbeddedDevice("ED-1", "Pi3", false, "192.168.1.44", "MD Ltd.Wifi-1"),
    new EmbeddedDevice("ED-2", "Pi4", false, "192.168.1.45", "eduroam"),
    new EmbeddedDevice("ED-3", "Pi4", false, "whatisIP", "MyWifiName"),
    new PC("Capital33", "BestPC_Ever", null, "456217865891789")
};


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}