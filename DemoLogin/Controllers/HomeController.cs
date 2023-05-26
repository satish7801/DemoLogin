
using DemoLogin.DTO;
using DemoLogin.Service.ServiceInterface;
using DemoLogin.ViewModel;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authservice;
        private readonly IConfiguration _configuration;


        public HomeController(ILogger<HomeController> logger, IAuthService authService, IConfiguration configuration)
        {
            _logger = logger;
            _authservice = authService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                foreach (var m in ModelState.Values)
                {
                    if (m.ValidationState.ToString().Equals("Invalid"))
                    {
                        TempData["error"] = m.Errors[0].ErrorMessage;
                    }
                }
                return RedirectToAction("Login");
            }

            UserDTO user = new UserDTO();
            user.Email = loginModel.Email;
            user.Password = loginModel.Password;

            user = _authservice.Login(user);

            TempData["success"] = "User Logged In Successfully";


            //var jwtSetting = _configuration.GetSection(nameof("JwtSetting")).Get<JwtSetting>();

            string token = _authservice.GenerateToken(user, _configuration["JwtSettings:Key"],
                _configuration["JwtSettings:Audience"], _configuration["JwtSettings:Issuer"]);

            HttpContext.Response.Cookies.Append("token", token);



            return RedirectToAction("Skill", "Admin");
        }

        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature?.Error; // Retrieve the exception

            // Handle the exception and return a custom error page or response
            // You can also log the exception or perform any other necessary actions

            return View("Error");
        }
    }
}