using LojaManoel.Application;
using LojaManoel.Application.Interfaces;
using LojaManoel.Infraestructure;
using LojaManoel.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AddDbContext();
builder.Services.AddScoped<ILojaManoelRepository, LojaManoelRepository>();
builder.Services.AddScoped<ICreatePedidoUseCase, CreatePedidoUseCase>();
builder.Services.AddScoped<IGetPedidosComCaixasUseCase, GetPedidosComCaixasUseCase>();


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





void AddDbContext()
{
    var connectionString = "Data Source=localhost;Initial Catalog=lojadomanoel;User ID=sa;Password=@Password123;Trusted_Connection=True;TrustServerCertificate=True;";

    builder.Services.AddDbContext<LojaManoelDbContext>(dbOptions =>
    {
        dbOptions.UseSqlServer(connectionString);
    });

}