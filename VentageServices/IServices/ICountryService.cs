using VentageRepositoryModel.Model;

namespace VentageServices.Services
{
    public interface ICountryService
    {
        Task<CountriesModel> GetAllCountries();
        Task<CountryModel> GetCountryById(int id);
    }
}