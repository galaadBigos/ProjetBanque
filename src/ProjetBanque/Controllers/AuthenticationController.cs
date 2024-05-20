using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ProjetBanque.Abstractions.Services;
using ProjetBanque.Services;

namespace ProjetBanque.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        private readonly ISecuriteService _securiteService;
        private string _baseAuthServiceUrl = "http://localhost:3000";

        public AuthenticationController()
        {
            _securiteService = new SecuriteService();
        }

        [HttpGet("/auth/login")]
        public async Task<IActionResult> LoginAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonBody = "{\"email\":\"test@test.fr\",\"password\":\"testtesttest\"}";
                    StringContent bodyContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    HttpResponseMessage response =
                        await client.PostAsync(_baseAuthServiceUrl + "/auth/login", bodyContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();


                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

                        JwtSecurityToken jwtToken = handler.ReadJwtToken(json);
                        _securiteService.UserId = jwtToken.Payload["UserId"].ToString();
                        return Ok(json);
                    }
                    else
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        return BadRequest(json);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}