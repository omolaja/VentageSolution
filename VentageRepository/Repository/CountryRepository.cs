using System;
using System.Data;
using System.Diagnostics.Metrics;
using Dapper;
using VentageRepositoryModel.Model;

namespace VentageRepository.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IDbConnection _dbConnection;

        public CountryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<CountryModel>> GetAllCountries()
        {
            var response = await _dbConnection.QueryAsync<CountryModel>("SELECT * FROM Country");
            return response;
        }

        public async Task<CountryModel> GetCountryById(int Id)
        {
            var response = await _dbConnection.QueryFirstOrDefaultAsync<CountryModel>("SELECT * FROM Country WHERE Id = @Id", new { Id = Id });
            return response;
        }
    }
}

