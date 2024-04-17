using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{
    [ApiController]
    [Route("/api/petTypes")]
    public class PetTypeController : ControllerBase
    {
        private readonly VeterinaryDbContext _context;

        public PetTypeController(VeterinaryDbContext context)
        {
            _context = context;
        }

        //Metodo Get por lista--- Select * From PetTypes
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.PetTypes.ToListAsync());
        }

        //Metodo post' Guardar registros
        [HttpPost]
        public async Task<ActionResult> Post(PetType petType)
        {
            _context.PetTypes.Add(petType);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Metodo Get por parametro' Select * From PetTypes
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var petType = await _context.PetTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (petType == null)
            {
                return NotFound(petType); //404
            }

            return Ok(petType);
        }

        //Metodo Put - Actualizar registros

        [HttpPut]
        public async Task<ActionResult> Put(PetType petType)
        {
            _context.PetTypes.Update(petType);
            await _context.SaveChangesAsync();
            return Ok(petType);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.PetTypes
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
