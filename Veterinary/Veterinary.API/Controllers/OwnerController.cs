using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{
    [ApiController]
    [Route("/api/owners")]
    public class OwnerController : ControllerBase
    {
        private readonly VeterinaryDbContext _context;

        public OwnerController(VeterinaryDbContext context)
        {
            _context = context;
        }

        //Metodo Get por lista--- Select * From Owners
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Owners.ToListAsync());
        }

        //Metodo post' Guardar registros
        [HttpPost]
        public async Task<ActionResult> Post(Owner owner)
        {
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Metodo Get por parametro' Select * From Owners
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var owner = await _context.Owners.FirstOrDefaultAsync();
            if (owner == null)
            {
                return NotFound(owner); //404
            }

            return Ok(owner);
        }

        //Metodo Put - Actualizar registros

        [HttpPut]
        public async Task<ActionResult> Put(Owner owner)
        {
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasafectadas = await _context.Owners.Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            if (filasafectadas == 0)
            {
                return NotFound(); //404
            }

            return NoContent(); //204
        }
    }
}