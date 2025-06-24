using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Data.Entities;
using UserManager.Data.Extensions;
using UserManager.Data.Interfaces;
using UserManagerApp.Web.DTOs;


namespace UserManager.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<PaginatedUserDTO> GetPaginatedUsersAsync(int pageNumber, int pageSize)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string procedure = "[UMA].[SP_GET_USERS]";
            const string countQuery = "SELECT TotalUsers FROM [UMA].[VW_USERS_COUNT];";

            try
            {
                var users = await connection.QueryAsync<UserME>(
                    procedure,
                    new { PageNumber = pageNumber, PageSize = pageSize },
                    commandType: CommandType.StoredProcedure
                );

                var totalCount = await connection.ExecuteScalarAsync<int>(countQuery);

                return new PaginatedUserDTO
                {
                    Users = users.Select(u => new UserDTO
                    {
                        IdUser = u.IdUser,
                        NameUser = u.NameUser,
                        BirthDate = u.BirthDate,
                        GenderId = u.IdGender
                    }).ToList(),
                    TotalCount = totalCount,
                    PageSize = pageSize,
                    CurrentPage = pageNumber
                };
            }
            catch (SqlException ex)
            {
                throw new DataException($"Error al obtener usuarios paginados: {ex.Message}", ex);
            }
        }

        public async Task<UserME> GetUserByIdAsync(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("El ID de usuario debe ser mayor que cero", nameof(userId));

            using var connection = _connectionFactory.CreateConnection();
            const string procedure = "[UMA].[SP_GET_USER_BY_ID]";

            try
            {
                var user = await connection.QueryFirstOrDefaultAsync<UserME>(
                    sql: procedure,
                    param: new { ID_USER = userId },
                    commandType: CommandType.StoredProcedure);

                return user ?? throw new KeyNotFoundException($"No se encontró el usuario con ID {userId}");
            }
            catch (SqlException ex)
            {
                throw new DataException($"{ex.Message}", ex);
            }
        }

        public async Task<List<GenderME>> GetAllGendersAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string query = "SELECT * FROM [UMA].[VW_GENDER_LIST];";

            var genders = await connection.QueryAsync<GenderME>(query);
            return genders.ToList();
        }

        public async Task<int> CreateUserAsync(UserME user)
        {
            UserValidator.Validate(user);

            using var connection = _connectionFactory.CreateConnection();
            const string procedure = "[UMA].[SP_INSERT_USER]";

            try
            {
                var result = await connection.QuerySingleOrDefaultAsync<int>(
                    procedure,
                    new
                    {
                        user.NameUser,
                        user.BirthDate,
                        user.IdGender
                    },
                    commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (SqlException ex)
            {
                throw new DataException($"{ex.Message}", ex);
            }
        }

        public async Task<UserME> UpdateUserAsync(UserME user)
        {
            UserValidator.Validate(user, requireId: true);

            using var connection = _connectionFactory.CreateConnection();
            const string procedure = "[UMA].[SP_UPDATE_USER]";

            try
            {
                await connection.ExecuteAsync(
                    procedure,
                    new
                    {
                        UserId = user.IdUser,
                        NameUser = user.NameUser,
                        DateOfBirth = user.BirthDate,
                        IdGender = user.IdGender
                    },
                    commandType: CommandType.StoredProcedure);

                return user;
            }
            catch (SqlException ex)
            {
                throw new DataException($"{ex.Message}", ex);
            }
        }



        public async Task<bool> DeleteUserAsync(int userId)
        {
            using var connection = _connectionFactory.CreateConnection();
            const string procedure = "[UMA].[SP_DELETE_USER]";

            try
            {
                var status = await connection.QuerySingleAsync<int>(
                    procedure,
                    new { IdUser = userId },
                    commandType: CommandType.StoredProcedure);

                return status == 1;
            }
            catch (SqlException ex)
            {
                throw new DataException($"{ex.Message}", ex);
            }
        }
    }
}
