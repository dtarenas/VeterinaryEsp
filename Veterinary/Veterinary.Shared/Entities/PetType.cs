using System.ComponentModel.DataAnnotations;

namespace Veterinary.Shared.Entities
{
    public class PetType
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Mascota")]
        [MaxLength(50, ErrorMessage = "{0} no puede superar {1} dígitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }
    }
}