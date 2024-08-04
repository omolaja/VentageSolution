using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using VentageRepositoryModel.Model;
using Dapper;
using VentageRepository.Repository;
using VentageServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register IDbConnection for dependency injection for inmemory database
builder.Services.AddSingleton<IDbConnection>(sp =>
{
    var connection = new SqliteConnection("DataSource=:memory:");
    connection.Open();

    // Create tables
    connection.Execute(@"
        CREATE TABLE IF NOT EXISTS Customers (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            PhoneNumber TEXT,
            Website TEXT,
            IsDeleted BOOLEAN NOT NULL DEFAULT 1,
            DateCreated TEXT DEFAULT (datetime('now'))
        );

        CREATE TABLE IF NOT EXISTS Contacts (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            FirstName TEXT,
            LastName TEXT,
            EmailAddress TEXT,
            PhoneNumber TEXT,
            CustomerId INTEGER,
            IsDeleted  BOOLEAN NOT NULL DEFAULT 1,
            FOREIGN KEY (CustomerId) REFERENCES Customers (Id)
        );

        CREATE TABLE IF NOT EXISTS CustomerAddress (
          Id INTEGER PRIMARY KEY AUTOINCREMENT,
          CustomerId INTEGER,
          CountryId  INTEGER,
          Address TEXT,
          PostCode TEXT,
          IsDeleted  BOOLEAN NOT NULL DEFAULT 1,
          FOREIGN KEY (CustomerId) REFERENCES Customers (Id),
          FOREIGN KEY (CountryId) REFERENCES Country(Id)
       );

       CREATE TABLE IF NOT EXISTS Country (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Name TEXT
       );
    ");

    // Insert default countries
    connection.Execute(@"
        INSERT INTO Country (Name) VALUES ('United Kingdom');
        INSERT INTO Country (Name) VALUES ('United States');
        INSERT INTO Country (Name) VALUES ('Nigeria');
        INSERT INTO Country (Name) VALUES ('South Africa');
    ");


    return connection;
});


//Dependecy Injection 
builder.Services.AddSingleton<ICustomerModel, CustomerModel>();
builder.Services.AddSingleton<DataObject>();
builder.Services.AddSingleton<ICountryModel, CountryModel>();
builder.Services.AddSingleton<ICustomerAddressModel, CustomerAddressModel>();
builder.Services.AddSingleton<IContactModel, ContactModel>();
builder.Services.AddSingleton<IContactRepository, ContactRepository>();
builder.Services.AddSingleton<ICountryRepository, CountryRepository>();
builder.Services.AddSingleton<ICustomerAddressRepository, CustomerAddressRepository>();
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<ResponseModel>();
builder.Services.AddSingleton<CountriesModel>();
builder.Services.AddSingleton<ICountryService, CountryService>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();


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

