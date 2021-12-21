using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboration1.DTOs;
using Laboration1.Entities;
using Laboration1.Repo;

namespace Labb1.Repo
{
    public class AnimalRepo : IAnimalRepo
    {
        //private List<Animal> _animals;

        private ApplicationContext _context;

        public AnimalRepo(ApplicationContext context)
        {
            // _animals = PopulateAnimalData();
            _context = context;
          
        }

        public Animal CreateAnimal(CreateAnimalDTO createAnimalDTO)
        {
            Animal animal = new Animal();
              animal.Animaltype = createAnimalDTO.Animaltype;
              animal.Name = createAnimalDTO.Name;
              _context.Animals.Add(animal);
              _context.SaveChanges();
              return animal;
           

        }

        public void DeleteAnimal(int id)
        {
            _context.Animals.Remove(GetByID(id));
            _context.SaveChanges();

        }

        public List<Animal> GetAll()
        {
            return _context.Animals.ToList();
        }



        public Animal GetByID(int id)
        {
            Animal animal = _context.Animals.Find(id);
            return animal;



        }


        public Animal UpdateAnimal(Animal animal, int id)
        {
            Animal existingAnimal = _context.Animals.FirstOrDefault(x => x.Id == id);
            if(existingAnimal != null)
            {
                existingAnimal.Animaltype = animal.Animaltype;
                existingAnimal.Name = animal.Name;

            }
            _context.SaveChanges();

            return existingAnimal;
        }
        /*
                private List<Animal> PopulateAnimalData()
                {
                    return new List<Animal>
        {


        new Animal
        {
        Id = 1,
        Animaltype="Frog",
        Name="Bob"
        },
        new Animal
        {
        Id = 2,
        Animaltype="Dog",
        Name="Pelle"
        },
        new Animal
        {
        Id = 3,
        Animaltype="Horse",
        Name="Lillen"
        },
        new Animal
        {
        Id = 4,
        Animaltype="Hamster",
        Name="Fred"
        },
        new Animal
        {
        Id = 5,
        Animaltype="Octopus",
        Name="Peter"
        }



        };
    }
        */

    }
}