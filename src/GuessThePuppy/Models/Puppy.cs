using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuessThePuppy.Models
{
    public class Puppy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int BreedId { get; set; }
        [ForeignKey("BreedId")]
        public Breed Breed { get; set; }
    }
}
