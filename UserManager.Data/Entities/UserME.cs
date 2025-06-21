using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Data.Entities
{
    public class UserME
    {
        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdGender { get; set; }
        public string Gender { get; set; }
    }
}