using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManager.Data.Entities;
using UserManager.Data.Interfaces;
using UserManager.Extensions;
using UserManagerApp.DTOs;

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

        [HttpGet("GetUsers")]
        public Task<IActionResult> GetUsersAsync() =>
            ControllerHelper.HandleRequestAsync(async () =>
            {
                var users = await _usersRepository.GetAllUsersAsync();
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

        [HttpPut("UpdateUser")]
        public Task<IActionResult> UpdateUser([FromBody] UserUpdateDTO userDto) =>
            ControllerHelper.HandleRequestAsync(async () =>
            {
                if (userDto == null)
                    return BadRequest("Los datos del cliente son inválidos.");

                if (userDto.IdUser <= 0)
                    return BadRequest("El ID del cliente no es válido.");

                var userEntity = _mapper.Map<UserME>(userDto);

                var updatedUser = await _usersRepository.UpdateUserAsync(userEntity);
                if (updatedUser == null)
                    return NotFound("Cliente no encontrado para actualizar.");

                return Ok(updatedUser);
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