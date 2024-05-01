using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Veterinary.Shared.Entities
{
    public class Pet
    {
        public int Id { get; set; }

        [Display(Name = "Nombre mascota")]
        [Required(ErrorMessage = "Campo {0} requerido")]
        [MaxLength(50, ErrorMessage = "{0} no puede superar {1} dígitos")]
        public string Name { get; set; }

        [Display(Name = "Foto mascota")]
        public string ImageUrl { get; set; }

        [Display(Name = "Raza")]
        [Required(ErrorMessage = "Campo {0} requerido")]
        [MaxLength(50, ErrorMessage = "{0} no puede superar {1} dígitos")]
        public string RaceType { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "Campo {0} requerido")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd HH:mm", ApplyFormatInEditMode = true)]
        public DateTime? BornDate { get; set; }

        [Display(Name = "Observaciones")]
        [MaxLength(500, ErrorMessage = "{0} no puede superar {1} dígitos")]
        public string Remarks { get; set; }

        public int Age => BornDate?.Year is null ? 0 : (DateTime.Now.Year - (BornDate?.Year ?? 0));

        [JsonIgnore]
        public Owner Owners { get; set; }

        [JsonIgnore]
        public PetType PetTypes { get; set; }

        [JsonIgnore]
        public ICollection<History> Histories { get; set; }

        [JsonIgnore]
        public ICollection<Agenda> Agendas { get; set; }
    }
}