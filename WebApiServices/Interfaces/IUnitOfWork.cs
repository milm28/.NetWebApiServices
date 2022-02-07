using System.Threading.Tasks;

namespace WebApiServices.Interfaces
{
    public interface IUnitOfWork
    {
         ICityRepository CityRepository{get;}
         Task<bool> SaveAsync();
    }
}