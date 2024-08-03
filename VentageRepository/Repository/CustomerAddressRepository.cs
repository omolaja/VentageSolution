using System;
using static VentageRepository.Repository.CustomerAddressRepository;
using System.Data;
using VentageRepositoryModel.Model;
using Dapper;
using System.Net;

namespace VentageRepository.Repository
{
    public class CustomerAddressRepository : ICustomerAddressRepository
    {

        private readonly IDbConnection _dbConnection;

        public CustomerAddressRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<CustomerAddressModel>> GetAllCustomerAddresses()
        {
            var response = await _dbConnection.QueryAsync<CustomerAddressModel>("SELECT * FROM CustomerAddress WHERE IsDeleted = 1");
            return response;
        }

        public async Task<CustomerAddressModel> GetCustomerAddressById(int Id)
        {
            var response = await _dbConnection.QueryFirstOrDefaultAsync<CustomerAddressModel>("SELECT * FROM CustomerAddress WHERE Id = @Id AND IsDeleted = 1",
                new { Id = Id });
            return response;
        }

        public async Task<int> CreateCustomerAddress(CustomerAddressModel entity)
        {
            var response = await _dbConnection.QuerySingleAsync<int>(@"
                INSERT INTO CustomerAddress (CustomerId, CountryId, Address, PostCode)
                VALUES (@CustomerId, @CountryId, @Address, @PostCode);
                SELECT last_insert_rowid();", new
            {
                CustomerId = entity.CustomerId,
                CountryId = entity.CountryId,
                Address = entity.Address,
                PostCode = entity.PostCode
            });
            return response;
        }

        public async Task<int> UpdateCustomerAddress(CustomerAddressModel entity)
        {
            var response = await _dbConnection.ExecuteAsync(@"
                UPDATE CustomerAddress
                SET CustomerId = @CustomerId, CountryId = @CountryId, Address = @Address, PostCode = @PostCode
                WHERE Id = @Id", new { CustomerId= entity.CustomerId, CountryId = entity.CountryId,
                Address = entity.Address,PostCode = entity.PostCode, Id = entity.Id
            });
            return response;
        }

        public async Task<int> DeleteCustomerAddress(int id)
        {
            var response = await _dbConnection.ExecuteAsync("UPDATE CustomerAddress SET IsDeleted = 0 WHERE Id = @Id", new { Id = id });
            return response;
        }

    }
}

