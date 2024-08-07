using Microsoft.OpenApi.Any;
using WeatherForcast;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.MapType<DateOnly>(() => new Microsoft.OpenApi.Models.OpenApiSchema
    {
        Format = "date",
        Type = "string",
        Example = new OpenApiString(DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
    });
});

builder.Services.AddScoped<HttpClient>();

var app = builder.Build();

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
