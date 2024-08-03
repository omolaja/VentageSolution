using System;
using System.Data;
using System.Xml.Linq;
using Dapper;
using VentageRepositoryModel.Model;

namespace VentageRepository.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomer()
        {
           
            var response = await _dbConnection.QueryAsync<CustomerModel>("SELECT * FROM Customers WHERE IsDeleted = 1");
            return response;
        }

        public async Task<CustomerModel> GetCustomerById(int Id)
        {
            var response = await _dbConnection.QueryFirstOrDefaultAsync<CustomerModel>("SELECT * FROM Customers WHERE Id = @Id AND IsDeleted = 1",
                new { Id = Id });
            return response;
        }

        public async Task<int> CreateCustomer(CustomerModel entity)
        {
            var response = await _dbConnection.QuerySingleAsync<int>(@"
                INSERT INTO Customers (Name, PhoneNumber, Website)
                VALUES (@Name, @PhoneNumber, @Website);
                SELECT last_insert_rowid();", new
            {
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                Website = entity.Website
            });
            return response;
        }

        public async Task<int> UpdateCustomer(CustomerModel entity)
        {
            var response = await _dbConnection.ExecuteAsync(@"
                UPDATE Customers
                SET Name = @Name, PhoneNumber = @PhoneNumber, Website = @Website
                WHERE Id = @Id", new { Name = entity.Name, PhoneNumber = entity.PhoneNumber, Website = entity.Website , Id = entity.Id});
            return response;
        }

        public async Task<int> DeleteCustomer(int Id)
        {
            var response = await _dbConnection.ExecuteAsync("UPDATE Customers SET IsDeleted = 0 WHERE Id = @Id", new { Id = Id });
            return response;
        }

    }
}

