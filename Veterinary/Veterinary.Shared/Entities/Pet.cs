using System.ComponentModel.DataAnnotations;

namespace Veterinary.Shared.Entities
{
    public class Pet
    {
        public int Id { get; set; }

        [Display(Name = "Nombre mascota")]
        [Required(ErrorMessage = "Campo {1} requerido")]
        [MaxLength(50, ErrorMessage = "{1} no puede superar {2} caracteres")]
        public string Name { get; set; }

        [Display(Name = "Foto mascota")]
        public string ImageUrl { get; set; }

        [Display(Name = "Raza mascota")]
        [Required(ErrorMessage = "Campo {1} requerido")]
        [MaxLength(50, ErrorMessage = "{1} no puede superar {2} caracteres")]
        public string RaceType { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "Campo requerido")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd HH:mm", ApplyFormatInEditMode = true)]
        public DateTime? BornDate { get; set; }

        [Display(Name = "Observaciones")]
        [MaxLength(500, ErrorMessage = "{1} no puede superar {2} caracteres")]
        public string Remarks { get; set; }

        public int Age => BornDate?.Year is null ? 0 : (DateTime.Now.Year - (BornDate?.Year ?? 0));

        public virtual Owner Owners { get; set; }
        public virtual PetType PetTypes { get; set; }

        public virtual ICollection<Agenda> Agendas { get; set; }

        public virtual ICollection<History> Histories { get; set; }
    }
}