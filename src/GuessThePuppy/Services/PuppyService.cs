using GuessThePuppy.Infrastructure;
using GuessThePuppy.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessThePuppy.Services {
    public class PuppyService {

        private PuppyRepository _puppyRepo;
        private Random _r;

        public PuppyService(PuppyRepository puppyRepo) {
            _puppyRepo = puppyRepo;
            _r = new Random();
        }
        //any public method in your service should // return DTO, NEVER and entity.
        public PuppyDTO GetRandomPuppy() {       
           
            return (from p in _puppyRepo.List()
                    select new PuppyDTO() {
                        Name = p.Name,
                        ImageUrl = p.ImageUrl
                    })
                    .Skip(_r.Next(_puppyRepo.Count))
                    .Take(1)
                    .FirstOrDefault();

        }
    }
}
