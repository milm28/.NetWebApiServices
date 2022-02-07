using System.Threading.Tasks;
using WebApiServices.Data.Repo;
using WebApiServices.Interfaces;

namespace WebApiServices.Data
{
    public class UnitOfWork : IUnitOfWork
    {

         private readonly DataContext dc;
        public UnitOfWork (DataContext dc){
            this.dc=dc;
        }
        public ICityRepository CityRepository => 
        
         new CityRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}