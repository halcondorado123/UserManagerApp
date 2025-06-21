using System.ComponentModel.DataAnnotations;
using UserManagerApp.Features;

namespace UserManagerApp.DTOs
{
    public class UserUpdateDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [AgeValidation(2, 95)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int GenderId { get; set; }
    }
}