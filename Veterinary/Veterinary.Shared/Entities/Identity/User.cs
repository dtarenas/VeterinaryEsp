using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Veterinary.Shared.Enums;

namespace Veterinary.Shared.Entities.Identity
{
    public class User : IdentityUser
    {
        [Display(Name = "Primer Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "No puede superar los {1} dígitos")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "No puede superar los {1} dígitos")]
        public string LastName { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(20, ErrorMessage = "No puede superar los {1} dígitos")]
        public string Document { get; set; }

        [Display(Name = "Direccion de residencia")]
        [MaxLength(100, ErrorMessage = "No puede superar los {1} dígitos")]
        public string Address { get; set; }

        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
