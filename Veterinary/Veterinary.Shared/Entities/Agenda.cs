using System.ComponentModel.DataAnnotations;

namespace Veterinary.Shared.Entities
{
    public class Agenda
    {
        public int Id { get; set; }

        [Display(Name = "Fecha de Cita")]
        [Required(ErrorMessage = "Campo requerido")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd HH:mm", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Reseña")]
        [MaxLength(100, ErrorMessage = "{1} no puede superar {2} caracteres")]
        public string Remarks { get; set; }

        [Display(Name = "Disponibilidad")]
        [Required(ErrorMessage = "Campo requerido")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Fecha de Cita local")]
        [Required(ErrorMessage = "Campo requerido")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd HH:mm", ApplyFormatInEditMode = true)]
        public DateTime DateLocal => Date.ToLocalTime();

        public virtual Owner Owners { get; set; }
        public virtual Pet Pets { get; set; }
    }
}