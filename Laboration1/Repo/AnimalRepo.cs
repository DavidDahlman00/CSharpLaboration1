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
        private List<Animal> _animals;



        public AnimalRepo()
        {
            _animals = PopulateAnimalData();
        }

        public Animal CreateAnimal(CreateAnimalDTO createAnimalDTO)
        {
             Animal animal = new Animal();
              animal.Id = _animals.Max(x => x.Id) + 1;
              animal.Animaltype = createAnimalDTO.Animaltype;
              animal.Name = createAnimalDTO.Name;
              _animals.Add(animal);
              return animal;
           

        }

        public void DeleteAnimal(int id)
        {
            _animals.Remove(GetByID(id));
        }

        public List<Animal> GetAll()
        {
            return _animals;
        }



        public Animal GetByID(int id)
        {
            Animal animal = _animals.Find(x => x.Id == id);
            return animal;



        }


        public Animal UpdateAnimal(Animal animal)
        {
            Animal existingAnimal = _animals.FirstOrDefault(x => x.Id == animal.Id);
            if(existingAnimal != null)
            {
                existingAnimal.Animaltype = animal.Animaltype;
                existingAnimal.Name = animal.Name;

            }

            return existingAnimal;
        }

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
    }
}