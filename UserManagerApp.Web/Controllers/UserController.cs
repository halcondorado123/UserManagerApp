using Microsoft.AspNetCore.Mvc;
using UserManagerApp.Web.DTOs;

namespace UserManagerApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://localhost:7034/api/User";

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(); 
        }

        public async Task<IActionResult> Search()
        {
            var users = await _httpClient.GetFromJsonAsync<List<UserDTO>>($"{_apiUrl}/GetUsers");
            return View("~/Views/Home/Search.cshtml", users);
        }


        public async Task<IActionResult> Consulta()
        {
            // Aquí usas HttpClient para llamar a la API
            // var usuarios = await _httpClient.GetFromJsonAsync<List<UsuarioDto>>("api/usuarios");
            return View(/*usuarios*/);
        }
    }
}
