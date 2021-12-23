using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboration1.DTOs;
using Laboration1.Entities;
using Laboration1.Repo;
using Microsoft.AspNetCore.Mvc;


/*
 Enviroment setup
• dotnet tool install -g dotnet-ef
• dotnet add package Pomelo.EntityFrameworkCore.MySql
• dotnet add package Microsoft.EntityFrameworkCore.Design

 MySql migration
• dotnet ef migrations add XXXXXXX
• dotnet ef database update
• dotnet watch run
*/



namespace Laboration1.Controllers
{
    [ApiController]
    [Route("animal")]

    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepo _repo;

        public AnimalController(IAnimalRepo repo)
        {
            _repo = repo;
        }

   
        //GET /animal
        [HttpGet]
        [Route("")]
        public IActionResult GetAnimals()
        {
            var animals = _repo
                .GetAll()
                .ToList()
                .MapToAnimalDTOs();
 
            return Ok(animals);


        }


        //GET /animal/:id

     
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAnimalByID(int id)
        {
            Animal animal = _repo.GetByID(id);
            if (animal is null) 
            {
                return NotFound("Could not find animal with ID " + id);
            }

            AnimalDTO animalDTO = animal.MapToAnimalDTO();         
            return Ok(animalDTO);
           ;
        }

        [HttpPost("")]
        public IActionResult CreateAnimal([FromBody] CreateAnimalDTO createAnimalDTO)
        {

            
             Animal createdAnimal = _repo.CreateAnimal(createAnimalDTO);
            //AnimalDTO animalDTO = MapAnimalToAnimalDTO(createdAnimal);

            AnimalDTO animalSavedDTO = _repo
                .GetByID(createdAnimal.Id)
                .MapToAnimalDTO();

            return CreatedAtAction(
                nameof(GetAnimalByID),
                new { id = animalSavedDTO.Id },
                animalSavedDTO);
        }

  

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            _repo.DeleteAnimal(id);
            return NoContent();
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal([FromBody] Animal animal, int id)
        {
            Animal updatedAnimal = _repo.UpdateAnimal(animal, id);

            AnimalDTO animalDTO = _repo.GetByID(id).MapToAnimalDTO();
            return Ok(animalDTO);
        }
        /*
        private AnimalDTO MapAnimalToAnimalDTO(Animal animal)
        {
            return new AnimalDTO
            {
                Id = animal.Id,
                AnimaltypeID = animal.AnimaltypeID,
                Name = animal.Name,
            };
        }*/
    }
}
