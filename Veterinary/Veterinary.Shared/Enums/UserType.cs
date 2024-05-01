using System.ComponentModel.DataAnnotations;

namespace Veterinary.Shared.Enums
{
    public enum UserType
    {
        [Display(Name = "Administrador")]
        Admin,

        [Display(Name = "Usuario")]
        User
    }
}