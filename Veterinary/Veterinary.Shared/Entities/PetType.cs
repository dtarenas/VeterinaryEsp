using System.ComponentModel.DataAnnotations;

namespace Veterinary.Shared.Entities
{
    public class PetType
    {
        public int Id { get; set; }

        [Display(Name = "Nombre mascota")]
        [MaxLength(50, ErrorMessage = "Nombre no puede superar 50 caracteres")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Name { get; set; }
    }
}