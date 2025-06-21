using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Data.Entities;

namespace UserManager.Data.Interfaces
{
    public interface IUsersRepository
    {
        Task<UserME> GetUserByIdAsync(int userId);
        Task<IEnumerable<UserME>> GetAllUsersAsync();
        Task<int> CreateUserAsync(UserME user);
        Task<UserME> UpdateUserAsync(UserME user);
        Task<bool> DeleteUserAsync(int userId);
    }
}
