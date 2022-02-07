using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiServices.Data;
using WebApiServices.Models;
using WebApiServices.Data.Repo;
using WebApiServices.Interfaces;
using WebApiServices.Dtos;
using AutoMapper;

namespace WebApiServices.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
    //private readonly DataContext dc;

        //public CityController(DataContext dc,ICityRepository repo)
        //{
          //  this.repo=repo;
          //  this.dc = dc;
        //}

        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;


        public CityController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow=uow;
            this.mapper=mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities= await uow.CityRepository.GetCitiesAsync();
                //manuelno mapiranje
            //var citiesDto= from c in cities
                //select new CityDto(){
                    //Id=c.Id,
                    //Name=c.Name
                //};

                //automapper
            var citiesDto =mapper.Map<IEnumerable<CityDto>>(cities);    
                
            return Ok(citiesDto);
        }

        //post metoda, saljemo podatke iz forme
        [HttpPost("add")]
        public async Task<IActionResult> AddCity(CityDto cityDto){

            //manuelno mapiranje
        //var city =new City {
            //Name=cityDto.Name,
            //LastUpdateBy=1,
            //LastUpdateOn=DateTime.Now
        //};
            //automapper
            var city=mapper.Map<City>(cityDto);
            city.LastUpdateBy=1;
            city.LastUpdateOn=DateTime.Now;    
            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return Ok(city);
        }

        [HttpPut("updateCityName/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityUpdateDto cityDto){

            var cityFromDto=await uow.CityRepository.FindCity(id);
            cityFromDto.LastUpdateBy=1;
            cityFromDto.LastUpdateOn=DateTime.Now;

            //cityDto je source, cityFromDto je target
            mapper.Map(cityDto,cityFromDto);
           // throw new Exception("Nesto nije u redu");
            await uow.SaveAsync();
            return StatusCode(200);
        }

        //delete metoda 
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id){
            uow.CityRepository.DeleteCity(id);
            await uow.SaveAsync();
            return Ok(id);
        }

      
    }
}