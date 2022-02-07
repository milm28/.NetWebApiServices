using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiServices.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="ovo Polje je obavezno!!!!")] 
        public String Name { get; set; }  

        public String Country { get; set; }
    }

    
}