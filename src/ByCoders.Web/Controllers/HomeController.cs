using ByCoders.Core.Identity;
using ByCoders.Core.Models;
using ByCoders.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ByCoders.Web.Controllers
{
    public class HomeController : MainController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authenticationService;
        private IAspNetUser _aspNetUser;
        private readonly ITituloService _tituloService;
        public HomeController(IAuthService authenticationService,
                              IAspNetUser aspNetUser,
                              ITituloService tituloService)
        {
            _authenticationService = authenticationService;
            _aspNetUser = aspNetUser;
            _tituloService = tituloService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin, string returnUrl = null)
        {
            if (!ModelState.IsValid) return View(userLogin);
            var result = await _authenticationService.Login(userLogin);
            if (!ResponseHasErrors(result.ResponseResult))
            {
                await LogIn(result);
                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction(actionName: "bycoders", controllerName: "Home");
                return LocalRedirect(returnUrl);
            }
            return View(userLogin);
        }

        [HttpGet]
        [Route("register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpGet]
        [Route("new")]
        public async Task<IActionResult> New()
        {
            return View();
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        #region "Private Methods"
        private async Task LogIn(UserResponseLogin userAnswersLogin)
        {
            var token = GetFormattedToken(userAnswersLogin.AccessToken);
            var claims = new List<Claim>();
            claims.Add(new Claim("JWT", userAnswersLogin.AccessToken));
            claims.AddRange(token.Claims);
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
        private static JwtSecurityToken GetFormattedToken(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }
        #endregion
    }
}
