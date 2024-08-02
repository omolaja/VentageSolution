using System;
using System.Data;
using System.Xml.Linq;
using Dapper;
using VentageRepositoryModel.Model;

namespace VentageRepository.Repository
{
	public class CustomerRepository
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

        public async Task<CustomerAddressModel> GetCustomerById(int id)
        {
            var response = await _dbConnection.QueryFirstOrDefaultAsync<CustomerAddressModel>("SELECT * FROM Customers WHERE Id = @Id AND IsDeleted = 1",
                new { Id = id });
            return response;
        }

        public async Task<int> CreateCustomer(CustomerModel entity)
        {
            var response = await _dbConnection.QuerySingleAsync<int>(@"
                INSERT INTO Customer (Name, PhoneNumber, Website)
                VALUES (@Name, @PhoneNumber, @Website);
                SELECT last_insert_rowid();", new
            {
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                Website =entity.Address
            });
            return response;
        }

        public async Task<int> UpdateCustomer(CustomerModel entity)
        {
            var response = await _dbConnection.ExecuteAsync(@"
                UPDATE Customer
                SET Name = @Name, PhoneNumber = @PhoneNumber, Website = @Website
                WHERE Id = @Id", new { Name = entity.Name, PhoneNumber = entity.PhoneNumber, Website = entity.Website });
            return response;
        }

        public async Task<int> DeleteCustomer(int id)
        {
            var response = await _dbConnection.ExecuteAsync("UPDATE Customer SET IsDeleted = 0 WHERE Id = @Id", new { Id = id });
            return response;
        }

    }
}

