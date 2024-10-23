using System.Collections.Generic;
using ArticleWebApi.Models;

namespace ArticleWebApi.DAL
{
    public interface ICountryServiceDAL
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
        void AddCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(int countryId);
    }
}
