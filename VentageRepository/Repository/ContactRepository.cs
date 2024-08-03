using System;
using System.Data;
using System.Net.Mail;
using System.Threading.Tasks;
using Dapper;
using VentageRepositoryModel.Model;

namespace VentageRepository.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbConnection _dbConnection;

        public ContactRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<ContactModel>> GetAllContact()
        {
            var response = await _dbConnection.QueryAsync<ContactModel>("SELECT * FROM Contacts WHERE IsDeleted = 1");
            return response;
        }

        public async Task<IEnumerable<ContactModel>> GetAllContactById(int Id)
        {
            var response = await _dbConnection.QueryAsync<ContactModel>("SELECT * FROM Contacts WHERE Id = @Id AND IsDeleted = 1",
                new { Id = Id });
            return response;
        }

        public async Task<ContactModel> GetContactById(int Id)
        {
            var response = await _dbConnection.QueryFirstOrDefaultAsync<ContactModel>("SELECT * FROM Contacts WHERE Id = @Id AND IsDeleted = 1",
                new { Id = Id });
            return response;
        }

        public async Task<int> CreateContact(ContactModel entity)
        {
            var response = await _dbConnection.QuerySingleAsync<int>(@"
                INSERT INTO Contacts (FirstName, LastName, EmailAddress, PhoneNumber, CustomerId)
                VALUES (@FirstName, @LastName, @EmailAddress, @PhoneNumber, @CustomerId);
                SELECT last_insert_rowid();", new
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                EmailAddress = entity.EmailAddress,
                PhoneNumber = entity.PhoneNumnber,
                CustomerId = entity.CustomerId
            });
            return response;
        }


        public async Task<int> UpdateContact(ContactModel entity)
        {
            var response = await _dbConnection.ExecuteAsync(@"
                UPDATE Contacts
                SET FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress, PhoneNumber = @PhoneNumber
                WHERE Id = @Id AND CustomerId = @CustomerId", new
            {
                Name = entity.FirstName,
                LastName = entity.LastName,
                EmailAddress = entity.EmailAddress,
                PhoneNumber = entity.PhoneNumnber,
                Id = entity.Id,
                CustomerId = entity.CustomerId
            });
            return response;
        }

        public async Task<int> DeleteCustomer(int Id)
        {
            var response = await _dbConnection.ExecuteAsync("UPDATE Contacts SET IsDeleted = 0 WHERE Id = @Id", new { Id = Id });
            return response;
        }

    }
}


