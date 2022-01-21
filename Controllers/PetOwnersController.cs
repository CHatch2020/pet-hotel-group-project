using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;


namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwners> GetAll() {
            return _context.PetOwners;
        }

        [HttpGet("{id}")]
        public ActionResult<PetOwners> GetById(int id)
        {
        PetOwners petOwners = _context.PetOwners
            .SingleOrDefault(PetOwners => PetOwners.id == id);

        // if (petOwners is null)
        // {
        //     return NotFound();
        // }

        return petOwners;
        }

        [HttpPost]
        public PetOwners Post(PetOwners petOwners)
        {
        _context.Add(petOwners);
        _context.SaveChanges();
        
        return petOwners;
        }


        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            PetOwners petOwners = _context.PetOwners.Find(id);
            _context.PetOwners.Remove(petOwners);
            _context.SaveChanges();
        }

        //   [HttpPut("{id}")]
        // public PetOwner Put(int id, PetOwner petOwner) 
        // {
        //     PetOwners petOwners = _context.PetOwners.Find(id);
        //     _context.PetOwners.Update(petOwners);
        //     _context.SaveChanges();
        // }
    }

}

