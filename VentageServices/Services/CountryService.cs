using System;
using System.Diagnostics.Metrics;
using VentageRepository.Repository;
using VentageRepositoryModel.Model;

namespace VentageServices.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly CountriesModel _countriesModel;

        public CountryService(ICountryRepository countryRepository, CountriesModel countriesModel)
        {
            _countryRepository = countryRepository;
            _countriesModel = countriesModel;
        }

        public async Task<CountriesModel> GetAllCountries()
        {
            var response = await _countryRepository.GetAllCountries();

            if (response.Count() > 0)
            {
                _countriesModel.responseCode = "00";
                _countriesModel.responseMessage = "Successful";
                _countriesModel.Countries = response.ToList();
            }
            else
            {
                _countriesModel.responseCode = "01";
                _countriesModel.responseMessage = "No Country list found";
            }

            return _countriesModel;
        }

        public async Task<CountryModel> GetCountryById(int id)
        {
            var response = await _countryRepository.GetCountryById(id);
            return response;
        }
    }
}

