using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Laboration1.Entities
{
    public class AnimalType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

     
        public List<Animal> Animals { get; set; }
    }
}
