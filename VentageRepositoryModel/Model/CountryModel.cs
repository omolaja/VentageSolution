using System;
namespace VentageRepositoryModel.Model
{
    public class CountryModel : DataObject, ICountryModel
    {
        public string Name { get; set; }
    }

    public class CountriesModel: ResponseModel
    {
        public List<CountryModel> CountryModels { get; set; }
    }
}

