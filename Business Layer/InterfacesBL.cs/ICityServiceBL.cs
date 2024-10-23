using System.Collections.Generic;
using ArticleWebApi.Models;

namespace ArticleWebApi.Services
{
    public interface ICityServiceBL
    {
        IEnumerable<object> GetAllCities();
        City GetCityById(int cityId);
        void AddCity(City city);
        void UpdateCity(City city);
        void DeleteCity(int cityId);
    }
}
