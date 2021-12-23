using System;
using System.Collections.Generic;
using Laboration1.Entities;
using System.Linq;

namespace Laboration1.DTOs
{
    public class AnimalTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AnimalDTO> Animals { get; set; }

    }


    public static class AnimalTypeDTOExtensions
    {

        public static AnimalTypeDTO MapToAnimalTypeDTO(this AnimalType animaltype)
        {
            return new AnimalTypeDTO
            {
                Id = animaltype.Id,
                Name = animaltype.Name,
                Animals = animaltype.Animals.MapToAnimalDTOs()                  
            };
        }
        
        public static List<AnimalTypeDTO> MapToAnimalTypeDTOs(this List<AnimalType> animalTypes)
        {
            return animalTypes.Select(a => a.MapToAnimalTypeDTO()).ToList();
        }
        
    }
}