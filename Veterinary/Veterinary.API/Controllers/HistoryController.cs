using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{
    [ApiController]
    [Route("/api/histories")]
    public class HistoryController : ControllerBase
    {
        private readonly VeterinaryDbContext _context;

        public HistoryController(VeterinaryDbContext context)
        {
            _context = context;
        }

        //Metodo Get por lista--- Select * From Histories
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Histories.ToListAsync());
        }

        //Metodo post' Guardar registros
        [HttpPost]
        public async Task<ActionResult> Post(History history)
        {
            _context.Histories.Add(history);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Metodo Get por parametro' Select * From Histories
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var history = await _context.Histories.FirstOrDefaultAsync(x => x.Id == id);
            if (history == null)
            {
                return NotFound(history); //404
            }

            return Ok(history);
        }

        //Metodo Put - Actualizar registros

        [HttpPut]
        public async Task<ActionResult> Put(History history)
        {
            _context.Histories.Update(history);
            await _context.SaveChangesAsync();
            return Ok(history);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.Histories
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