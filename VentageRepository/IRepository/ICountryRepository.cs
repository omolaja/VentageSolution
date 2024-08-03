using VentageRepositoryModel.Model;

namespace VentageRepository.Repository
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryModel>> GetAllCountries();
        Task<CountryModel> GetCountryById(int id);
    }
}