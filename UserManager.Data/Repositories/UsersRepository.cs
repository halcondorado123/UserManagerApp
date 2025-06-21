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


namespace UserManager.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<UserME>> GetAllUsersAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            const string procedure = "[UMA].[SP_GET_USERS]";

            try
            {
                return await connection.QueryAsync<UserME>(
                    sql: procedure,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw new DataException($"{ex.Message}", ex);
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
