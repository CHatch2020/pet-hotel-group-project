using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetAll()
        {
            return _context.Pet
                // Include the `petOwner` property
                // which is a list of `Pet` objects
                // .NET will do a JOIN for us!
                .Include(Pet => Pet.petOwner);
        }

// ADAM IS JUST TRYING STUFF HERE
        [HttpPost]
        public Pet Post(Pet pet)
        {
          // Tell the DB context about our new pet object
        _context.Add(pet);
          // ...and save the pet object to the database
        _context.SaveChanges();

          // Respond back with the created pet object
        return pet;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Find the bread, by ID
            Pet pet = _context.Pet.Find(id);

            // Tell the DB that we want to remove this bread
            _context.Pet.Remove(pet);

            // ...and save the changes to the database
            _context.SaveChanges();
        }


        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    }
}
