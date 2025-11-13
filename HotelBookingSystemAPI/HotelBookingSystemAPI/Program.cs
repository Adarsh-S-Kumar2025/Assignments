using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystemAPI.Infrastructure.Data;
using HotelBookingSystemAPI.Application.Hotel.Commands.CreateHotel;

var builder = WebApplication.CreateBuilder(args);

// Configuration: connection string fallback to the same one used by DbContext.OnConfiguring
var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Database=HotelBookingDb;User Id=sa;Password=12345678Aa;TrustServerCertificate=true;";

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core DbContext
builder.Services.AddDbContext<HotelBookingDbContext>(options =>
    options.UseSqlServer(defaultConnection));

// MediatR - explicitly register the assembly that contains your handlers
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateHotelCommandHandler).Assembly));

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Apply pending EF migrations at startup (optional)
using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<HotelBookingDbContext>();
        db.Database.Migrate();
    }
    catch
    {
        // swallow or log as appropriate for your environment
    }
}

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();