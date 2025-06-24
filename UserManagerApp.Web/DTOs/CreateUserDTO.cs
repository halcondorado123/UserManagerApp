using System.ComponentModel.DataAnnotations;

namespace UserManagerApp.Web.DTOs
{
    public class CreateUserDTO
    {
        public string NameUser { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdGender { get; set; }
    }
}
