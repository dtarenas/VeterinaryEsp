using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{
    [ApiController]
    [Route("/api/serviceTypes")]
    public class ServiceTypeController : ControllerBase
    {
        private readonly VeterinaryDbContext _context;

        public ServiceTypeController(VeterinaryDbContext context)
        {
            _context = context;
        }

        //Metodo Get por lista--- Select * From ServiceTypes
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.ServiceTypes.ToListAsync());
        }

        //Metodo post' Guardar registros
        [HttpPost]
        public async Task<ActionResult> Post(ServiceType serviceType)
        {
            _context.ServiceTypes.Add(serviceType);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Metodo Get por parametro' Select * From ServiceTypes
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var serviceType = await _context.ServiceTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (serviceType == null)
            {
                return NotFound(serviceType); //404
            }

            return Ok(serviceType);
        }

        //Metodo Put - Actualizar registros

        [HttpPut]
        public async Task<ActionResult> Put(ServiceType serviceType)
        {
            _context.ServiceTypes.Update(serviceType);
            await _context.SaveChangesAsync();
            return Ok(serviceType);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRoes = await _context.ServiceTypes
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (affectedRoes == 0)
            {
                return NotFound(); //404
            }

            return NoContent(); //204
        }
    }
}
