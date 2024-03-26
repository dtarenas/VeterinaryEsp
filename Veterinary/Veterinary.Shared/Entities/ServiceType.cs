using System.ComponentModel.DataAnnotations;

namespace Veterinary.Shared.Entities
{
    public class ServiceType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo servicio")]
        [MaxLength(50, ErrorMessage = "Nombre no puede superar 50 caracteres")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Name { get; set; }

        public virtual ICollection<History> Histories { get; set; }
    }
}