# VentageSolution
1. Design Decisions

a. In-Memory Database: The implementation uses an in-memory SQLite database for simplicity and ease of setup during development.

b. Database Schema: The schema is designed with basic tables (Customers, Contacts, CustomerAddress, Country) and relationships to cover the primary entities and their associations.


c. Soft Deletion: The design includes a soft delete mechanism (IsDeleted flag) to mark records as deleted without physically removing them from the database. This approach allows for data recovery and auditing.

d. Dependency Injection: ASP.NET Core's dependency injection (DI) framework is used to manage service lifetimes and dependencies, with singleton lifetimes chosen to maintain a single instance of each service and repository throughout the application's lifetime.

e. Dapper: Dapper is chosen for ORM due to its lightweight nature and simplicity, which provides efficient and straightforward data access.


2. Tools and Technologies Used
   
a. Framework: .NET 7 and above can be used to execute the code.

b. ASP.NET Core: Used for building the web API and handling dependency injection.

c. SQLite: In-memory database for data storage during development.

d. Dapper: Micro ORM for data access.

e. Swagger/OpenAPI: Used for API documentation and testing.

f. C#: Programming language for implementation.

g. Dependency Injection (DI): Used to manage service lifetimes and dependencies.


3. Improvements and Future Enhancements
   
a. Persistent Database: The in-memory SQLite database should be replaced with a persistent database such as SQL Server, PostgreSQL, or a cloud-based database for production use.

b. Database Migrations: Implement database migration tools like Entity Framework Core Migrations to manage schema changes over time.

c. Caching: Introduce caching mechanisms to improve performance by reducing database load for frequently accessed data.

d. Pagination and Filtering: Implement pagination and filtering for endpoints that return lists of data to handle large datasets more efficiently.

e. Error Handling: Enhance error handling and logging mechanisms to provide more insightful diagnostics and maintainability.

f. Unit Testing: Increase test coverage with unit tests for repository methods and service logic to ensure reliability and correctness.

g. Security: Implement robust authentication and authorization mechanisms to secure the API.




