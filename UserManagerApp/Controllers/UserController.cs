using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using UserManager.Data.Entities;
using UserManager.Data.Interfaces;
using UserManager.Extensions;
using UserManagerApp.DTOs;
using UserManagerApp.Web.DTOs;

namespace UserManagerApp.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UserController(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        [HttpGet("GetPaginatedUsers")]
        public Task<IActionResult> GetPaginatedUsersAsync(int pageNumber = 1) =>
            ControllerHelper.HandleRequestAsync(async () =>
            {
                const int pageSize = 5;
                var users = await _usersRepository.GetPaginatedUsersAsync(pageNumber, pageSize);
                return Ok(users);
            });

        [HttpGet("GetUserById")]
        public Task<IActionResult> GetUserByIdAsync(int userId) =>
            ControllerHelper.HandleRequestAsync(async () =>
            {
                var user = await _usersRepository.GetUserByIdAsync(userId);
                if (user == null) return NotFound("Cliente no encontrado.");
                return Ok(user);
            });

        [HttpGet("GetAllGenders")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genders = await _usersRepository.GetAllGendersAsync();

            var genderDtos = _mapper.Map<List<GenderDTO>>(genders);
            return Ok(genderDtos);
        }

        [HttpPost("CreateUser")]
        public Task<IActionResult> CreateUserAsync([FromBody] UserCreateDTO userDto) =>
            ControllerHelper.HandleRequestAsync(async () =>
            {
                if (userDto == null)
                    return BadRequest("Los datos del cliente son inválidos.");

                var userEntity = _mapper.Map<UserME>(userDto);

                var createdUserId = await _usersRepository.CreateUserAsync(userEntity);

                return Ok(new { UserId = createdUserId });
            });

        [HttpPost("UpdateUser")]
        public Task<IActionResult> UpdateUser([FromBody] UserDTO userDto) =>
            ControllerHelper.HandleRequestAsync(async () =>
            {
                if (userDto == null)
                    return BadRequest("Los datos del usuario son inválidos.");

                if (userDto.IdUser <= 0)
                    return BadRequest("El ID del usuario no es válido.");

                var userEntity = _mapper.Map<UserME>(userDto);
                var updatedUser = await _usersRepository.UpdateUserAsync(userEntity);

                if (updatedUser == null)
                    return NotFound("Usuario no encontrado para actualizar.");

                return Ok();
            });

        [HttpDelete("DeleteStudent")]
        public Task<IActionResult> DeleteUser(int userId) =>
            ControllerHelper.HandleRequestAsync(async () =>
            {
                var deletedClient = await _usersRepository.DeleteUserAsync(userId);
                if (deletedClient == null)
                    return NotFound("Cliente no encontrado para eliminar.");

                return Ok(deletedClient);
            });
    }
}