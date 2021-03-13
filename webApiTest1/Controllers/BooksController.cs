using Bookstore.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace webApiTest1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookServices _bookServices;
        public BooksController(IBookServices bookServices)
        {
            _bookServices = bookServices;

        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_bookServices.GetBooks());
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            if (userName == "admin" && password == "1234")
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name,userName)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                return Ok(_bookServices.GetBookAuth());
            }
            else
            {
                return Ok(_bookServices.GetBookNoAuth());
            }
        }

        [HttpPost("Protected")]
        public IActionResult Protected()
        {
            if (HttpContext.User.Identity == null || HttpContext.User.Identity.Name==null)
            {
                return StatusCode(401);
            }
            Console.Out.WriteLine(HttpContext.User.Identity.Name);
            return Ok(_bookServices.GetProtectedBook());

        }
    }
}
