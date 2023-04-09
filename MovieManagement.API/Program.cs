using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieManagement.Core.Repository;
using MovieManagement.Infrastructure.Context;
using MovieManagement.Infrastructure.Implementations;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//adding entity framework core
builder.Services.AddDbContext<MovieManagementDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MovieConnection")));

//adding unit of work to the dependency injection container 

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

//to ignore cyles

builder.Services.AddMvc().AddJsonOptions(X => X.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//this is where we build the app and all the dependencies should come before the build other wise it will crash 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
