using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Data.Enums
{
    public enum Status
    {
        [Display(Name = "Aktywny")]
        Active = 1,
        [Display(Name = "Nieaktywny")]
        Inactive = 2,
        [Display(Name = "Usunięty")]
        Removed = 3,
    }
}
