using System.ComponentModel.DataAnnotations;
using UserManagerApp.Features;

namespace UserManagerApp.DTOs
{
    public class UserCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string NameUser { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [AgeValidation(2, 95)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int IdGender { get; set; }
    }
}