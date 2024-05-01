using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Veterinary.Shared.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Campo {0} requerido")]
        [MaxLength(50, ErrorMessage = "{0} no puede superar {1} dígitos")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Campo {0} requerido")]
        [MaxLength(50, ErrorMessage = "{0} no puede superar {1} dígitos")]
        public string LastName { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage = "Campo {0} requerido")]
        [MaxLength(20, ErrorMessage = "{0} no puede superar {1} dígitos")]
        public string Document { get; set; }

        [Display(Name = "Correo eletronico")]
        [Required(ErrorMessage = "Campo {0} requerido")]
        [MaxLength(255, ErrorMessage = "No puede superar los 50 digitos")]
        [EmailAddress(ErrorMessage = "Formato invalido")]
        public string EmailAddress { get; set; }

        [Display(Name = "Telefono")]
        [MaxLength(10, ErrorMessage = "{0} no puede superar {1} dígitos")]
        public string FixedPhone { get; set; }

        [Display(Name = "Telefono Movil")]
        [MaxLength(10, ErrorMessage = "{0} no puede superar {1} dígitos")]
        public string ContactPhone { get; set; }

        [Display(Name = "Direccion de residencia")]
        [MaxLength(100, ErrorMessage = "{0} no puede superar {1} dígitos")]
        public string Address { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [JsonIgnore]
        public virtual ICollection<Agenda> Agendas { get; set; }
    }
}