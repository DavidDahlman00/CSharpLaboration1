using System;
using System.Collections.Generic;
using Laboration1.DTOs;
using Laboration1.Entities;

namespace Laboration1.Repo
{
    public interface IAnimalRepo
    {
        List<Animal> GetAll();

        Animal GetByID(int id);

        Animal CreateAnimal(CreateAnimalDTO createAnimalDTO);

        void DeleteAnimal(int id);

       Animal UpdateAnimal(Animal animal);
    }
}
