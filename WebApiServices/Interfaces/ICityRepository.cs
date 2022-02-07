using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiServices.Models;

namespace WebApiServices.Interfaces
{
    public interface ICityRepository
    {
         Task<IEnumerable<City>> GetCitiesAsync();
         void AddCity(City city);
         void DeleteCity(int CityId);
        Task<City> FindCity(int id);
        //Task<bool> SaveAsync();  //koristicemo u unit of work pattern-u
    }
}