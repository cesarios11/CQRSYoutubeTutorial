using CQRS.Practico.Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//TODO: Mediator recibe como parámetro del assembly en el cual va a encontrar todos
//los comandos, queries y handlers y todos los objetos que va a estar mediando.
//TODO: Conecta los comandos con su handler, las queries con su handler.
builder.Services.AddMediatR(typeof(Program).Assembly);

//TODO:Se registra una base de datos en memoria con el nombre de 'TaskDb'
builder.Services.AddDbContext<ApplicationDbContext>(options=>
options.UseInMemoryDatabase("TaskDb"));

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
