using System.Text.Json.Serialization;
using BatizadoDoNovato.Context;
using BatizadoDoNovato.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddControllers()
    .AddJsonOptions(e => e
    .JsonSerializerOptions
    .ReferenceHandler
    = ReferenceHandler
    .IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddDbContext<ApplicationDbContext>(e => e
    .UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ProdutoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
