using GuessThePuppy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessThePuppy.Infrastructure {
    public class PuppyRepository {
        private ApplicationDbContext _db;

        public PuppyRepository(ApplicationDbContext db) {
            _db = db;

        }
        public int Count {
            get {
                return _db.Puppies.Count();
            }
        }
        public IQueryable<Puppy> List() {

            return _db.Puppies;
        }
    }
}
