using System;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GuessThePuppy.Models
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();


            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }

            var breeds = new List<Breed> {
               new Breed() {Name = "Border Collie" },
               new Breed() {Name = "Black Lab" },
               new Breed() {Name = "Golden Retriever" },
               new Breed() {Name = "Weimaraner" }
            };
            for (int i = 0; i < breeds.Count; i++) {
                var breed = breeds[i];
                var dbBreed = db.Breeds.FirstOrDefault(b => b.Name == breed.Name);

                if (dbBreed == null) {
                    db.Breeds.Add(breed);
                } else {
                    breeds[i] = dbBreed;
                }
            }
            db.SaveChanges();


            var puppies = new List<Puppy> {
                new Puppy() {
                    Name = "Havoc",
                    Breed = breeds.FirstOrDefault(b => b.Breed == "Black Lab"),
                    ImageUrl = 
                },
                new Puppy() {
                    Name = "Gnarles Barkley",
                    Breed = breeds.FirstOrDefault(b => b.Breed == "Golden Retriever"),
                    ImageUrl =
                },
                new Puppy() {
                    Name = "Breezy Fresh",
                    Breed = breeds.FirstOrDefault(b => b.Breed == "Weimaranaer"),
                    ImageUrl = https://scontent-dfw1-1.xx.fbcdn.net/v/t1.0-9/11218618_10154183311565676_5996913615304760079_n.jpg?oh=10d9648b1cdd11153f2a8700fe95efc2&oe=57D7E6D5
            }
            };
            for (int i = 0; i < puppies.Count; i++) {
                var puppy = puppies[i];
                var dbPuppy = db.Puppies.FirstOrDefault(b => b.Name == puppy.Name);

                if (dbPuppy == null) {
                    db.Puppies.Add(puppy);
                } else {
                    puppies[i] = dbPuppy;
                }
            }
            db.SaveChanges();

        }

    }
}
