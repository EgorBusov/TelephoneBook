using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using TelephoneBookWeb.ApiInteraction;
using TelephoneBookWeb.ModelsAuth;

namespace TelephoneBookWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiRequests _apiRequests;
        public AccountController(ApiRequests apiRequests)
        {
            _apiRequests = apiRequests;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [Microsoft.AspNetCore.Mvc.Route("Login")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Login(UserModel user)
        {
            try
            {
                TokenResponse token = await _apiRequests.LoginRequest(user);
                Response.Cookies.Append("jwt", token.token, new CookieOptions //кладем токен в куки
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict //указывает, что cookie может быть отправлен только на тот же сайт, на котором он был создан
                });
                Console.WriteLine(token.token);
                return Redirect("/Persone/GetPersones");
            }
            catch(HttpResponseException ex)
            {
                if(ex.Response.StatusCode == HttpStatusCode.Unauthorized) {
                    ModelState.AddModelError("", "Пользователь не найден");
                    return View(user);
                }
                else 
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(user); 
                }
            }
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [Microsoft.AspNetCore.Mvc.Route("Register")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Register(UserModel user)
        {
            try
            {
                TokenResponse token = await _apiRequests.RegisterRequest(user);
                Response.Cookies.Append("jwt", token.token, new CookieOptions //кладем токен в куки
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict //указывает, что cookie может быть отправлен только на тот же сайт, на котором он был создан
                });
                Console.WriteLine(token.token);
                return Redirect("/Persone/GetPersones");
            }
            catch(HttpResponseException ex) 
            {
                if(ex.Response.StatusCode == HttpStatusCode.Conflict)
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                    return View();
                }
            }

        }
        /// <summary>
        /// доступ запрещен
        /// </summary>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult Denied() 
        { 
            return View();
        }
        /// <summary>
        /// Выход
        /// </summary>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Redirect("/Account/Login");
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        /// <summary>
        /// Получение всех user
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var token = Request.Cookies["jwt"];
                ViewBag.Users = await _apiRequests.GetUsers(token);
                return View();
            }
            catch (HttpResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Unauthorized) { return Redirect("/Account/Login"); }
                else if (ex.Response.StatusCode == HttpStatusCode.Forbidden) { return Redirect("/Account/Denied"); }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                    return View();
                }
            }
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            try
            {
                var token = Request.Cookies["jwt"];
                await _apiRequests.DeleteUser(userName, token);
                return Redirect("/Account/GetUsers");
            }
            catch (HttpResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Unauthorized) { return Redirect("/Account/Login"); }
                else if (ex.Response.StatusCode == HttpStatusCode.Forbidden) { return Redirect("/Account/Denied"); }
                else if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    ModelState.AddModelError("", "Такой пользователь отсутствует");
                    return Redirect("/Account/GetUsers");
                }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                    return Redirect("/Account/GetUsers");
                }
            }
        }
    }
}
