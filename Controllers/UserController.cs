using apiTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Security.AccessControl;
using Crypt = System.Security.Cryptography;

namespace apiTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<JsonResult> getUser(string uid)
        {
            computeAt(Uuser.users.First().password , out string aT);
            Request.Headers.TryGetValue("accessToken", out var aaT);
            
            if (aaT.FirstOrDefault() != aT)
            {
                return  new JsonResult(Unauthorized("invalid token"));
            }
            var user = new Uuser()
            {
                age = Random.Shared.Next(20, 35),
                city = "Cairo",
                country = "Egypt",
                email = $"Email_U{uid}@gmail.com",
                name = $"user_{uid}",
                password = $"password_{uid}",
                phone = "+2010022003302",
            };

            return new JsonResult(Ok(user));
        }

        [HttpGet]
        public async Task<JsonResult> getUserUnSecure(string uid)
        {
            var user = new Uuser()
            {
                age = Random.Shared.Next(20, 35),
                city = "Cairo",
                country = "Egypt",
                email = $"Email_U{uid}@gmail.com",
                name = $"user_{uid}",
                password = $"password_{uid}",
                phone = "+2010022003302",
            };

            return new JsonResult(Ok(user));
        }

        [HttpGet]
        public async Task<JsonResult> login(string username, string password)
        {
            var user = Uuser.users.Find(x =>
            {
                return x.email.Trim().ToLower() == username.Trim().ToLower();
            });

            if (user is null)
            {
                return new JsonResult(NotFound("User not found;"));
            }
            if (user.password.Trim() != password.Trim())
            {
                return new JsonResult(Unauthorized("Username or Password is not correct;"));
            }

            computeAt(password, out string aT);
            var now = DateTime.UtcNow;
            return new JsonResult(Ok(new Llogin()
            {
                username = username,
                accessToken = aT,
                expiresAt = new DateTime(year: now.Year, month: now.Month, day: now.Day).Add(new TimeSpan(hours: now.Hour+1, minutes:00, seconds:00)).ToLocalTime(),
            }));
        }

        public static void computeAt(string password, out string aT)
        {
            var date = DateTime.Now;
            using (var crypt = new Crypt.HMACSHA512(System.Text.Encoding.UTF8.GetBytes($"{date.Year}{date.Month}{date.Day}{date.Hour}")))
            {
                aT =$"am{Convert.ToBase64String( crypt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)))}";
            }
        }
    }
}
