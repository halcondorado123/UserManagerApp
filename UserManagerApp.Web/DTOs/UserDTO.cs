using System.ComponentModel.DataAnnotations;

namespace UserManagerApp.Web.DTOs
{
    public class UserDTO
    {
        public int IdUser { get; set; }

        [Display(Name = "Nombre")]
        public string NameUser { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int GenderId { get; set; }

    }
}
