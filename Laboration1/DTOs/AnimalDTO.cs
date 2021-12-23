using System;
using System.Collections.Generic;
using System.Linq;
using Laboration1.Entities;

namespace Laboration1.DTOs
{
    public class AnimalDTO
    {
        public int Id { get; set; }
        public BasicAnimalTypeDTO AnimalType { get; set; }
        public string Name { get; set; }
    }
    public static class AnimalDtoExtension
    {
  
        public static AnimalDTO MapToAnimalDTO(this Animal animal)
        {
            return new AnimalDTO
            {
                Id = animal.Id,
                AnimalType = animal.AnimalType.MapToBasicAnimalTypeDTO(),
                Name = animal.Name,
            };

        }


        public static List<AnimalDTO> MapToAnimalDTOs(this List<Animal> animals)
        {
            return animals.Select(v => v.MapToAnimalDTO()).ToList();
        }
    }

}
