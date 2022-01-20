using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnerController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnerController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwners> GetAll() {
            return _context.PetOwners;
        }

          // GET /api/bakers
        // [HttpGet]
        // public IEnumerable<Baker> GetAll()
        // {
        //   return _context.Bakers;
        //   // SELECT * FROM Bakers
        // }



        [HttpGet("{id}")]
        public ActionResult<PetOwners> GetById(int id)
        {
        PetOwners petOwners = _context.PetOwners
            .SingleOrDefault(PetOwners => PetOwners.id == id);

        if (petOwners is null)
        {
            return NotFound();
        }

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
    }

}

