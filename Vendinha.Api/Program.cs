using Microsoft.EntityFrameworkCore;
using Vendinha.Contexts;
using Vendinha.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetConnectionString("Postgres");
builder.Services.AddDbContext<VendinhaDbContext>(o => o.UseNpgsql(connString));

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<DividaService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
