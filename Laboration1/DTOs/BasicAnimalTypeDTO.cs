using System;
using System.Collections.Generic;
using System.Linq;
using Laboration1.Entities;

namespace Laboration1
{
    public class BasicAnimalTypeDTO
    {
        public int ID { get; set; }

        public string Species { get; set; }
    }

    public static class BasicAnimalTypeDTOs

    {

        public static BasicAnimalTypeDTO MapToBasicAnimalTypeDTO(this AnimalType animalType)
        {

            return new BasicAnimalTypeDTO
            {
                ID = animalType.Id,
                Species = animalType.Name,

            };

        }

        public static List<BasicAnimalTypeDTO> MapToBasicAnimalTypeDTOs(this List<AnimalType> animalTypes)
        {
            return animalTypes.Select(a => a.MapToBasicAnimalTypeDTO()).ToList();
        }
    }
}



