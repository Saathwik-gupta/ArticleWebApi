using System.Collections.Generic;
using System.Linq;
using ArticleWebApi.Data;
using ArticleWebApi.Models;

namespace ArticleWebApi.DAL
{
    public class CountryServiceDAL : ICountryServiceDAL
    {
        private readonly ArticleContext _context;

        public CountryServiceDAL(ArticleContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(int countryId)
        {
            return _context.Countries.Find(countryId);
        }

        public void AddCountry(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
        }

        public void UpdateCountry(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();
        }

        public void DeleteCountry(int countryId)
        {
            var country = _context.Countries.Find(countryId);
            if (country != null)
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();
            }
        }
    }
}
