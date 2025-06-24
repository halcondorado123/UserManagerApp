using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UserManagerApp.Features;

namespace UserManagerApp.DTOs
{
    public class UserCreateDTO
    {
        public string NameUser { get; set; }
        public DateTime BirthDate { get; set; }

        [JsonPropertyName("idGender")]
        public int GenderId { get; set; }
    }
}