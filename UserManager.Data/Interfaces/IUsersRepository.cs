using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Data.Entities;
using UserManagerApp.Web.DTOs;

namespace UserManager.Data.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<GenderME>> GetAllGendersAsync();
        Task<PaginatedUserDTO> GetPaginatedUsersAsync(int pageNumber, int pageSize);
        Task<UserME> GetUserByIdAsync(int userId);
        Task<int> CreateUserAsync(UserME user);
        Task<UserME> UpdateUserAsync(UserME user);
        Task<bool> DeleteUserAsync(int userId);
    }
}
