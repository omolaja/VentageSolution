# VentageSolution
1. Design Decisions
In-Memory Database: The implementation uses an in-memory SQLite database for simplicity and ease of setup during development. This setup is useful for testing and development purposes but should be replaced with a persistent database for production.
Database Schema: The schema is designed with basic tables (Customers, Contacts, CustomerAddress, Country) and relationships to cover the primary entities and their associations.
Soft Deletion: The design includes a soft delete mechanism (IsDeleted flag) to mark records as deleted without physically removing them from the database. This approach allows for data recovery and auditing.
Dependency Injection: ASP.NET Core's dependency injection (DI) framework is used to manage service lifetimes and dependencies, with singleton lifetimes chosen to maintain a single instance of each service and repository throughout the application's lifetime.
Dapper: Dapper is chosen for ORM due to its lightweight nature and simplicity, which provides efficient and straightforward data access.


2. Tools and Technologies Used
Framework: .NET 7 and above can be used to execute the code.
ASP.NET Core: Used for building the web API and handling dependency injection.
SQLite: In-memory database for data storage during development.
Dapper: Micro ORM for data access.
Swagger/OpenAPI: Used for API documentation and testing.
C#: Programming language for implementation.
Dependency Injection (DI): Used to manage service lifetimes and dependencies.

3. Improvements and Future Enhancements
Persistent Database: The in-memory SQLite database should be replaced with a persistent database such as SQL Server, PostgreSQL, or a cloud-based database for production use.
Database Migrations: Implement database migration tools like Entity Framework Core Migrations to manage schema changes over time.
Caching: Introduce caching mechanisms to improve performance by reducing database load for frequently accessed data.
Pagination and Filtering: Implement pagination and filtering for endpoints that return lists of data to handle large datasets more efficiently.
DTOs (Data Transfer Objects): Use DTOs to decouple the internal data models from the API contracts, allowing for more flexible and versioned API design.
Error Handling: Enhance error handling and logging mechanisms to provide more insightful diagnostics and maintainability.
Unit Testing: Increase test coverage with unit tests for repository methods and service logic to ensure reliability and correctness.
Security: Implement robust authentication and authorization mechanisms to secure the API.

3. Improvements and Future Enhancements
Persistent Database: The in-memory SQLite database should be replaced with a persistent database such as SQL Server, PostgreSQL, or a cloud-based database for production use.
Stored Procedures: Utilize stored procedures for complex database operations to improve performance and maintainability, and to encapsulate logic within the database.
Database Migrations: Implement database migration tools like Entity Framework Core Migrations to manage schema changes over time.
Caching: Introduce caching mechanisms to improve performance by reducing database load for frequently accessed data.
Pagination and Filtering: Implement pagination and filtering for endpoints that return lists of data to handle large datasets more efficiently.
DTOs (Data Transfer Objects): Use DTOs to decouple the internal data models from the API contracts, allowing for more flexible and versioned API design.
Error Handling: Enhance error handling and logging mechanisms to provide more insightful diagnostics and maintainability.
Unit Testing: Increase test coverage with unit tests for repository methods and service logic to ensure reliability and correctness.
Security: Implement robust authentication and authorization mechanisms to secure the API.



Test Parameter

CREATING A NEW CUSTOMER

Sample Payload for creating new customer

REQUEST

{
  "name": "Oladipo Omolaja",
  "address": {
    "address": "43 Tavistock Street Lution",
    "postCode": "LU1 3UT",
    "countryId": "1"
  },
  "phoneNumber": "07587993349",
  "website": "https://localhost:7291/swagger/index.html",
  "contacts": [
    {
     "customerId": 0,
      "firstName": "Oladipo",
      "lastName": "Oladipo",
      "emailAddress": "dipo142008@gmail.com",
      "phoneNumnber": "07587993349"
    }
  ]
}

RESPONSE

{
  "responseCode": "00",
  "responseMessage": "Successfully Created"
}

