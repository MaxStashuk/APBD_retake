using WEB.Models.DTOs;
using WEB.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddTransient<IMobileService, MobileService>(
    _ => new MobileService(connectionString)
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/mobiles/", (IMobileService service) =>
{
    try
    {
        return Results.Ok(service.GetAllNumbers());
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message); 
    }
});

app.MapPost("/api/mobiles/", (IMobileService service, CreateDto dto) =>
{
    
})


app.Run();