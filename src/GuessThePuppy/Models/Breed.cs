using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessThePuppy.Models
{
    public class Breed
    {
        internal string Breed;

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Puppy> Puppies { get; set; }
    }
}
