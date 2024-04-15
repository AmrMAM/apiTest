using apiTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace apiTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> getUser(string uid)
        {
            var user = new User() {
                age = Random.Shared.Next(20, 35),
                city = "Cairo",
                country = "Egypt",
                email = $"Email_U{uid}@gmail.com",
                name = $"user_{uid}",
                password = $"password_{uid}",
                phone = "+2010022003302",
            };

            return Ok( user);
        }
    }
}
