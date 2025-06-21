using System.ComponentModel.DataAnnotations;

namespace UserManagerApp.DTOs
{
    public class UserDeleteDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
    }
}