using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UserManagerApp.Features;

namespace UserManagerApp.DTOs
{
    public class UserUpdateDTO
    {
        [Required]
        public int IdUser { get; set; }

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