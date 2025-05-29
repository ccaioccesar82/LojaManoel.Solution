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

var applyMigrations = builder.Configuration.GetValue<bool>("APPLY_MIGRATIONS");

if (applyMigrations)
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<LojaManoelDbContext>();

        var pendingMigrations = dbContext.Database.GetPendingMigrations();
        if (pendingMigrations.Any())
        {
            dbContext.Database.Migrate();
        }

    }

}

app.Run();





void AddDbContext()
{
    var connectionString = builder.Configuration.GetConnectionString("Connection");

    builder.Services.AddDbContext<LojaManoelDbContext>(dbOptions =>
    {
        dbOptions.UseSqlServer(connectionString);
    });

}