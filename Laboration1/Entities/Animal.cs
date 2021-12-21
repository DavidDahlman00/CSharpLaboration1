using System;
using System.ComponentModel.DataAnnotations;

namespace Laboration1.Entities
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Animaltype { get; set; }

        [Required]
        public string Name { get; set; }

    }
}