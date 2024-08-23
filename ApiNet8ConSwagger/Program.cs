using ApiNet8ConSwagger.DataContexts;
using Microsoft.EntityFrameworkCore;
using ApiNet8ConSwagger.Services.Interface;
using ApiNet8ConSwagger.Services.infrastructures;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var stringConnection = builder.Configuration.GetConnectionString("CubeConnection");

builder.Services.AddDbContext<DbContextCube>( opt => opt.UseSqlServer (stringConnection, o => o.UseCompatibilityLevel(120)));
builder.Services.AddScoped<IArticoliRepository, ArticoliRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
