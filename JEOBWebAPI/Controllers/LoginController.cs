using JEOBWebAPI.Models.Data;
using JEOBWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JEOBWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        protected readonly LoginService _LoginService;
        private readonly DataContext _context;
        public LoginController(DataContext context) { 
            _LoginService = new LoginService(context); 
            this._context = context;
        }


        [HttpPost, ActionName("Login")]
        public IActionResult Login(LoginInput login) {
            return Ok(this._LoginService.Verifylogin(login));
        }
    }
}
