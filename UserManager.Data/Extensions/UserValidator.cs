using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Data.Entities;

namespace UserManager.Data.Extensions
{
    public static class UserValidator
    {
        public static void Validate(UserME user, bool requireId = false)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (requireId && user.IdUser <= 0)
                throw new ArgumentException("El ID del usuario no es válido", nameof(user.IdUser));

            if (string.IsNullOrWhiteSpace(user.NameUser))
                throw new ArgumentException("El nombre del usuario no puede estar vacío", nameof(user.NameUser));

            if (user.BirthDate > DateTime.Now.AddYears(-2) || user.BirthDate < DateTime.Now.AddYears(-95))
                throw new ArgumentException("La fecha de nacimiento no es válida", nameof(user.BirthDate));

            if (user.IdGender <= 0)
                throw new ArgumentException("El género seleccionado no es válido", nameof(user.IdGender));
        }
    }
}