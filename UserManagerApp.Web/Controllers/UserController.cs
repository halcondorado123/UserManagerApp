using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
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
        public async Task<IActionResult> Search(int page = 1, int pageSize = 10)
        {
            var usersTask = _httpClient.GetFromJsonAsync<PaginatedUserDTO>(
                $"{_apiUrl}/GetPaginatedUsers?pageNumber={page}&pageSize={pageSize}");

            var gendersTask = _httpClient.GetFromJsonAsync<List<GenderDTO>>(
                $"{_apiUrl}/GetAllGenders");

            await Task.WhenAll(usersTask, gendersTask);

            var users = usersTask.Result;
            var genders = gendersTask.Result;

            ViewBag.Genders = genders;
            return View("~/Views/Home/Search.cshtml", users);
        }

        [HttpGet]
        public async Task<IActionResult> GetGenders()
        {
            try
            {
                var genders = await _httpClient.GetFromJsonAsync<List<GenderDTO>>($"{_apiUrl}/GetAllGenders");
                return Ok(genders);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener géneros: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UserDTO user)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_apiUrl}/UpdateUser", user);

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, redirectUrl = Url.Action("Search", new { page = 1 }) });
                }

                var error = await response.Content.ReadAsStringAsync();
                return BadRequest($"Error de API: {error}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Excepción: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int userId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_apiUrl}/DeleteStudent?userId={userId}");

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, redirectUrl = Url.Action("Search", new { page = 1 }) });
                }

                var error = await response.Content.ReadAsStringAsync();
                return BadRequest($"Error de API: {error}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Excepción: {ex.Message}");
            }
        }
    }
}
