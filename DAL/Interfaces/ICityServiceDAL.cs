using System.Collections.Generic;
using ArticleWebApi.Models;

namespace ArticleWebApi.DAL
{
    public interface ICityServiceDAL
    {
        IEnumerable<object> GetAllCities();
        City GetCityById(int cityId);
        void AddCity(City city);
        void UpdateCity(City city);
        void DeleteCity(int cityId);
    }
}
