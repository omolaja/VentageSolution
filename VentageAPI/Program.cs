using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using VentageRepositoryModel.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the in-memory SQLite database
var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();

//Dependecy Injection
builder.Services.AddSingleton<IDbConnection>(connection);
builder.Services.AddSingleton<ICustomerModel, CustomerModel>();
builder.Services.AddSingleton<DataObject>();

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

