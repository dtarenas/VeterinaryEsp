using Microsoft.EntityFrameworkCore;
using VeterinaryEsp.Shared.Entities;

namespace VetrinaryEsp.API.Data
{
    public class VeterinaryEspContext : DbContext
    {
        public VeterinaryEspContext(DbContextOptions<VeterinaryEspContext> options) : base(options)
        {


        }

        public DbSet<Owner> Owners { get; set; }
    }
}
