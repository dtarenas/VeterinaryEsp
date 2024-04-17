using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{
    [ApiController]
    [Route("/api/pets")]
    public class PetController : ControllerBase
    {
        private readonly VeterinaryDbContext _context;

        public PetController(VeterinaryDbContext context)
        {
            _context = context;
        }

        //Metodo Get por lista--- Select * From Pets
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Pets.ToListAsync());
        }

        //Metodo post' Guardar registros
        [HttpPost]
        public async Task<ActionResult> Post(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Metodo Get por parametro' Select * From Pets
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);
            if (pet == null)
            {
                return NotFound(pet); //404
            }

            return Ok(pet);
        }

        //Metodo Put - Actualizar registros

        [HttpPut]
        public async Task<ActionResult> Put(Pet pet)
        {
            _context.Pets.Update(pet);
            await _context.SaveChangesAsync();
            return Ok(pet);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.Pets
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (affectedRows == 0)
            {
                return NotFound(); //404
            }

            return NoContent(); //204
        }
    }
}
