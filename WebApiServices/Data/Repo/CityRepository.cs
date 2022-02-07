using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiServices.Models;
using WebApiServices.Interfaces;

namespace WebApiServices.Data.Repo
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext dc;
        public CityRepository (DataContext dc){
            this.dc=dc;
        }

        
        public void AddCity(City city)
        {
            dc.Cities.AddAsync(city); //u interface smo stavili da je add async metoda
        }

        public void DeleteCity(int CityId)
        {
            var city=dc.Cities.Find(CityId);
            dc.Cities.Remove(city);
        }

        public async Task<City> FindCity(int id)
        {
            return await dc.Cities.FindAsync(id);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await dc.Cities.ToListAsync();
        }

        //koristimo unitofwork pattern, pa nam zato nije potreban metoda
        //public async Task<bool> SaveAsync()
        //{
            //return await dc.SaveChangesAsync() > 0;
       // }
    }
}