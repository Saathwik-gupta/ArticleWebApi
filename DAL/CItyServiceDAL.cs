using System.Collections.Generic;
using System.Linq;
using ArticleWebApi.Data;
using ArticleWebApi.Models;

namespace ArticleWebApi.DAL
{
    public class CityServiceDAL : ICityServiceDAL
    {
        private readonly ArticleContext _context;

        public CityServiceDAL(ArticleContext context)
        {
            _context = context;
        }

        public IEnumerable<object> GetAllCities()
        {
            var citiesWithArticles = _context.Cities
                .Select(city => new
                {
                    CityId = city.CityId,
                    CityName = city.CityName,
                    StateId = city.StateId,
                    ArticleIds = city.Article_Cities.Select(ac => ac.ArticleId).ToList()
                })
                .ToList();

            return citiesWithArticles;
        }

        public City GetCityById(int cityId)
        {
            return _context.Cities.Find(cityId);
        }

        public void AddCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }

        public void UpdateCity(City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();
        }

        public void DeleteCity(int cityId)
        {
            var city = _context.Cities.Find(cityId);
            if (city != null)
            {
                _context.Cities.Remove(city);
                _context.SaveChanges();
            }
        }
    }
}
