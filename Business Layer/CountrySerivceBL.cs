using System.Collections.Generic;
using ArticleWebApi.DAL;
using ArticleWebApi.Models;

namespace ArticleWebApi.Services
{
    public class CountryServiceBL : ICountryServiceBL
    {
        private readonly ICountryServiceDAL _countryDal;

        public CountryServiceBL(ICountryServiceDAL countryDal)
        {
            _countryDal = countryDal;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _countryDal.GetAllCountries();
        }

        public Country GetCountryById(int countryId)
        {
            return _countryDal.GetCountryById(countryId);
        }

        public void AddCountry(Country country)
        {
            _countryDal.AddCountry(country);
        }

        public void UpdateCountry(Country country)
        {
            _countryDal.UpdateCountry(country);
        }

        public void DeleteCountry(int countryId)
        {
            _countryDal.DeleteCountry(countryId);
        }
    }
}
