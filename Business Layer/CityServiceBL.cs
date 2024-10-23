using System.Collections.Generic;
using ArticleWebApi.DAL;
using ArticleWebApi.Models;

namespace ArticleWebApi.Services
{
    public class CityServiceBL : ICityServiceBL
    {
        private readonly ICityServiceDAL _cityDAL;

        public CityServiceBL(ICityServiceDAL cityDAL)
        {
            _cityDAL = cityDAL;
        }

        public IEnumerable<object> GetAllCities()
        {
            return _cityDAL.GetAllCities();
        }

        public City GetCityById(int cityId)
        {
            return _cityDAL.GetCityById(cityId);
        }

        public void AddCity(City city)
        {
            _cityDAL.AddCity(city);
        }

        public void UpdateCity(City city)
        {
            _cityDAL.UpdateCity(city);
        }

        public void DeleteCity(int cityId)
        {
            _cityDAL.DeleteCity(cityId);
        }
    }
}
