using GuessThePuppy.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessThePuppy.Controllers{
    [Route("api/[controller]")]
    public class BreedsController : Controller {
        private ApplicationDbContext _db;

        public BreedsController(ApplicationDbContext db) {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Breed> Get() {
            return _db.Breeds.ToList();
        }
        
    }
}
