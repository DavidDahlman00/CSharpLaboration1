using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboration1.DTOs;
using Laboration1.Entities;
using Laboration1.Repo;
using Microsoft.AspNetCore.Mvc;
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
            var animals = _repo.GetAll();
            var animals2 = animals.Select(v => new AnimalDTO
            {
                Id = v.Id,
                Animaltype = v.Animaltype,
                Name = v.Name
            })
                .OrderBy(x => x.Name);
            return Ok(animals);
            //List<Animal> animals = _repo.GetAll();
            //return Ok(animals);
        }


        //GET /animal/:id

     
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAnimalByID(int id)
        {
            Animal animal = _repo.GetByID(id);
            if (animal is null) // animal == null
            {
                return NotFound("Could not find animal with ID " + id);
            }

            AnimalDTO animalDTO = MapAnimalToAnimalDTO(animal);
            return Ok(animalDTO);
            //return _repo.GetByID(id);
        }

        [HttpPost("")]
        public IActionResult CreateAnimal([FromBody] CreateAnimalDTO createAnimalDTO)
        {

            
             Animal createdAnimal = _repo.CreateAnimal(createAnimalDTO);
            AnimalDTO animalDTO = MapAnimalToAnimalDTO(createdAnimal);

            return CreatedAtAction(
                nameof(GetAnimalByID),
                new { id = animalDTO.Id },
                animalDTO);
        }

  

        [HttpDelete("{id}")]
        public IActionResult DeleteVinyl(int id)
        {
            _repo.DeleteAnimal(id);
            return NoContent();
        }
        
        [HttpPut]
        public Animal UpdateAnimal([FromBody] Animal animal, int id)
        {
            _repo.UpdateAnimal(animal, id);
            return animal;
        }

        private AnimalDTO MapAnimalToAnimalDTO(Animal animal)
        {
            return new AnimalDTO
            {
                Id = animal.Id,
                Animaltype = animal.Animaltype,
                Name = animal.Name,
            };
        }
    }
}
