using ClarivateRestApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClarivateRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RandomUserController : ControllerBase
    {
        private IUserService _userService;
        private readonly IConfiguration _configuration;
        public RandomUserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] User model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            else
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        var baseUrl = _configuration.GetValue<string>("BaseUrl:url");
                        client.BaseAddress = new Uri(baseUrl.ToString());
                        var response = await client.GetAsync(baseUrl);
                        response.EnsureSuccessStatusCode();
                        return Ok(JsonConvert.DeserializeObject<UserApiResponseObject>(await response.Content.ReadAsStringAsync()));
                    }
                    catch (HttpRequestException httpRequestException)
                    {
                        return BadRequest($"Error: {httpRequestException.Message}");
                    }
                }
            }
        }
    }
}
