using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Veterinary.Shared.Entities
{
    public class ServiceType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo servicio")]
        [MaxLength(50, ErrorMessage = "{0} no puede superar {1} dígitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<History> Histories { get; set; }
    }
}