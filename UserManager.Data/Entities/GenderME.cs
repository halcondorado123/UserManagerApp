using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Data.Entities
{
    public class GenderME
    {
        public int IdGender { get; set; }
        public string GenderName { get; set; }
        public ICollection<UserME> Users { get; set; }
    }
}