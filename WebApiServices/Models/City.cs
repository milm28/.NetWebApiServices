using System;

namespace WebApiServices.Models
{
    public class City
    {
        public int Id { get; set; } 
        public String Name { get; set; }  

        public DateTime LastUpdateOn { get; set; }  
        public int LastUpdateBy { get; set; }
    }
}