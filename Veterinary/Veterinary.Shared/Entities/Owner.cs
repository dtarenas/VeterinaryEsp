using System.ComponentModel.DataAnnotations;

namespace Veterinary.Shared.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        [Display(Name = "Primer Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50, ErrorMessage = "No puede superar los 50 digitos")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50, ErrorMessage = "No puede superar los 50 digitos")]
        public string LastName { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(13, ErrorMessage = "No puede superar los 50 digitos")]
        public string Document { get; set; }

        [Display(Name = "Correo eletronico")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(255, ErrorMessage = "No puede superar los 50 digitos")]
        [EmailAddress(ErrorMessage = "Formato invalido")]
        public string EmailAddress { get; set; }

        [Display(Name = "Telefono")]
        [MaxLength(10, ErrorMessage = "No puede superar los 10 digitos")]
        public string FixedPhone { get; set; }

        [Display(Name = "Telefono Movil")]
        [MaxLength(10, ErrorMessage = "No puede superar los 10 digitos")]
        public string ContactPhone { get; set; }

        [Display(Name = "Direccion de residencia")]
        [MaxLength(10, ErrorMessage = "No puede superar los 10 digitos")]
        public string Address { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}