using GuessThePuppy.Infrastructure;
using GuessThePuppy.Models;
using GuessThePuppy.Services;
using GuessThePuppy.Services.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessThePuppy.Controllers {
    [Route("api/[controller]")]
    public class PuppiesController : Controller {

        private PuppyService _puppyService;

        public PuppiesController(PuppyService puppyService) {
            _puppyService = puppyService;
        }

        //GET: api/values
        [HttpGet("random")]
        public PuppyDTO GetRandomPuppy() {
            return _puppyRepo.GetRandomPuppy().FirstOrDefault();
        }
    }
}
