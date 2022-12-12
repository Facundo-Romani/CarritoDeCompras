using CarritoDeCompras.Context;
using CarritoDeCompras.Services;
using CarritoDeCompras.Services.ServicesContract;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DBContext.
builder.Services.AddDbContext<DbContextCarrito>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarritoConnection"));
});

// Services.
builder.Services.AddScoped<IUsuarioService,  UsuarioService>();
builder.Services.AddScoped<ICarritoService, CarritoService>();
builder.Services.AddScoped<ITipoDescuentoCarrito , TipoDescuentoCarrito>();

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
