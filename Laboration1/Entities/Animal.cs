using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboration1.Entities
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Animaltype")]
        public int AnimaltypeID { get; set; }

        public AnimalType AnimalType { get; set; }

        //[Required]
        //public string Animaltype { get; set; }

        [Required]
        public string Name { get; set; }

    }
}