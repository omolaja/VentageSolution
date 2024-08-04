# VentageAPISolution

# Introduction

VentageAPI is a user-friendly API designed to streamline the creation and management of Ventage customers. It empowers client applications to seamlessly interact with the Ventage platform by sending requests to create new users and manage their details efficiently.

VentageAPI provides a set of well-defined endpoints that allow for the comprehensive handling of customer data, including their personal information, contact details, and addresses. The API ensures data consistency, security, and ease of integration, making it an ideal solution for businesses looking to integrate Ventage customer creation capabilities into their applications.

Key features of VentageAPI include: (https://github.com/omolaja/VentageSolution/blob/main/VentageAPIDOCUMENTATION.pdf)

a Customer Creation: Easily create new Ventage customers by sending requests with the necessary information.

b. Data Management: Manage customer details, including personal information, contact details, and addresses.

c. Security: Secure endpoints to ensure the protection of customer data.

d. Scalability: Designed to handle high volumes of customer creation requests efficiently.

e. Documentation: Comprehensive documentation to facilitate easy integration and usage.

VentageAPI is built using modern technologies and follows best practices in API development, ensuring reliability and performance. Whether you are developing a web application, mobile app, or any other client application, VentageAPI provides the tools you need to integrate Ventage customer management seamlessly.

# Clone the repository
git clone https://github.com/omolaja/VentageSolution.git

# Navigate to the project directory
cd VengageSolution


# 1. Design Decisions

a. In-Memory Database: The implementation uses an in-memory SQLite database for simplicity and ease of setup during development.

b. Database Schema: The schema is designed with basic tables (Customers, Contacts, CustomerAddress, Country) and relationships to cover the primary entities and their associations.


c. Soft Deletion: The design includes a soft delete mechanism (IsDeleted flag) to mark records as deleted without physically removing them from the database. This approach allows for data recovery and auditing.

d. Dependency Injection: ASP.NET Core's dependency injection (DI) framework is used to manage service lifetimes and dependencies, with singleton lifetimes chosen to maintain a single instance of each service and repository throughout the application's lifetime.

e. Dapper: Dapper is chosen for ORM due to its lightweight nature and simplicity, which provides efficient and straightforward data access.


# 2. Application Structure using Repository Pattern

The application structure is organized into several layers to ensure the separation of concerns and maintainability. The key layers are:

a. Model Layer (VentageRepositoryModel): Defines the data models used throughout the application.

b. Repository Layer (VentageRepository): Contains repositories that handle data access and manipulation.

c. Service Layer (VentageServices): Encapsulates the business logic and interacts with repositories.

d. Controller Layer (VentageAPI): Handles HTTP requests and returns responses to client applications.

This structure ensures a clean separation of concerns and makes the application easy to maintain and extend. Each layer has a distinct responsibility, and dependency injection is used to manage dependencies between layers.


# 3. Tools and Technologies Used
   
a. Framework: .NET 7 and above can be used to execute the code.

b. ASP.NET Core: Used for building the web API and handling dependency injection.

c. SQLite: In-memory database for data storage during development. (https://github.com/omolaja/VentageSolution/blob/main/VentageDatabaseDiagram.pdf)

d. Dapper: Micro ORM for data access.

e. Swagger/OpenAPI: Used for API documentation and testing. (https://github.com/omolaja/VentageSolution/blob/main/openapi.pdf)

f. C#: Programming language for implementation.

g. Dependency Injection (DI): Used to manage service lifetimes and dependencies.


# 4. Improvements and Future Enhancements
   
a. Persistent Database: The in-memory SQLite database should be replaced with a persistent database such as SQL Server, PostgreSQL, or a cloud-based database for production use.

b. Database Migrations: Implement database migration tools like Entity Framework Core Migrations to manage schema changes over time.

c. Caching: Introduce caching mechanisms to improve performance by reducing database load for frequently accessed data.

d. Pagination and Filtering: Implement pagination and filtering for endpoints that return data lists to handle large datasets more efficiently.

e. Error Handling: Enhance error handling and logging mechanisms to provide more insightful diagnostics and maintainability.

f. Unit Testing: Increase test coverage with unit tests for repository methods and service logic to ensure reliability and correctness.

g. Security: Implement robust authentication and authorization mechanisms to secure the API.


# 5. Development Time

   The application took about 2 hours to develop, with an additional 3 hours on documentation.

# 6. Contributing
   
Guidelines for contributing to the project.

a. Fork the repository.

b. Create a new branch (git checkout -b feature/your-feature).

c. Commit your changes (git commit -am 'Add some feature').

d. Push to the branch (git push origin feature/your-feature).

e. Create a new Pull Request.


