using Basic_Web_API.Models;

namespace Basic_Web_API.Services.Interface
{
    public interface ICountryService
    {
        List<Country> GetAllCountries();
        Country GetCountryById(int id);
        void CreateCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(int id);
    }
}
