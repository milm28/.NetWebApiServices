using Microsoft.EntityFrameworkCore;
using WebApiServices.Models;

namespace WebApiServices.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options){}

        //entiti iz modela
        //code first, kreiramo tabelu u bazi Cities
        public DbSet<City> Cities{get;set;}


    }
}