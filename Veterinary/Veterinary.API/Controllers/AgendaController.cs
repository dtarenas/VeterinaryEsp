using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{
    [ApiController]
    [Route("/api/agendas")]
    public class AgendaController : ControllerBase
    {
        private readonly VeterinaryDbContext _context;

        public AgendaController(VeterinaryDbContext context)
        {
            _context = context;
        }

        //Metodo Get por lista--- Select * From Agendas
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Agendas.ToListAsync());
        }

        //Metodo post' Guardar registros
        [HttpPost]
        public async Task<ActionResult> Post(Agenda agenda)
        {
            _context.Agendas.Add(agenda);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Metodo Get por parametro' Select * From Agendas
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var agenda = await _context.Agendas.FirstOrDefaultAsync(x => x.Id == id);
            if (agenda == null)
            {
                return NotFound(agenda); //404
            }

            return Ok(agenda);
        }

        //Metodo Put - Actualizar registros

        [HttpPut]
        public async Task<ActionResult> Put(Agenda agenda)
        {
            _context.Agendas.Update(agenda);
            await _context.SaveChangesAsync();
            return Ok(agenda);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.Agendas
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