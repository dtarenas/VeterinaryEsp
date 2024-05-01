using System.ComponentModel.DataAnnotations;

namespace Veterinary.Shared.Entities
{
    public class History
    {
        public int Id { get; set; }

        [Display(Name = "Fecha Atención")]
        [Required(ErrorMessage = "Campo requerido")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd HH:mm", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "{1} no puede superar {2} caracteres")]
        [Required(ErrorMessage = "Campo {0} requerido")]
        public string Description { get; set; }

        [Display(Name = "Observaciones")]
        [MaxLength(500, ErrorMessage = "{1} no puede superar {2} caracteres")]
        public string Remarks { get; set; }

        [Display(Name = "Fecha Atención Local")]
        [Required(ErrorMessage = "Campo requerido")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd HH:mm", ApplyFormatInEditMode = true)]
        public DateTime DateLocal => Date.ToLocalTime();

        public virtual Pet Pets { get; set; }
        public virtual ServiceType ServiceTypes { get; set; }
    }
}