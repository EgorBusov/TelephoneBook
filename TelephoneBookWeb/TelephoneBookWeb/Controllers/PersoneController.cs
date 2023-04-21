using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using TelephoneBookWeb.ApiInteraction;
using TelephoneBookWeb.Models;

namespace TelephoneBookWeb.Controllers
{

    public class PersoneController : Controller
    {
        private readonly ApiRequests _apiRequests;
        public PersoneController(ApiRequests apiRequests)
        {
            _apiRequests = apiRequests;
        }
        /// <summary>
        /// Список записей
        /// </summary>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> GetPersones()
        {
            ViewBag.Persones = await _apiRequests.GetPersones();
            return View();
        }
        /// <summary>
        /// Полная инф о записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet] 
        public async Task<IActionResult> GetOnePersoneById(int id)
        {
            try
            {
                var token = Request.Cookies["jwt"];//достаем токен из куки
                if (token == null) { return Redirect("/Account/Login"); }
                Persone persone = await _apiRequests.GetOnePersoneById(id, token);
                return View(persone);
            }
            catch (HttpResponseException ex)
            {

                if(ex.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Redirect("/Account/Login");
                }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(id);
                }
            }
        }
        /// <summary>
        /// Добавление записи
        /// </summary>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult PersoneAdd()
        {
            return View();
        }
        /// <summary>
        /// Добавление записи
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="SurName"></param>
        /// <param name="FatherName"></param>
        /// <param name="Telephone"></param>
        /// <param name="Address"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> PersoneAdd(string Name, string SurName, string FatherName, string Telephone,
            string Address, string Description)
        {
            try
            {
                Persone persone = new Persone()
                {
                    Name = Name,
                    SurName = SurName,
                    FatherName = FatherName,
                    Telephone = Telephone,
                    Address = Address,
                    Description = Description
                };
                var token = Request.Cookies["jwt"];//достаем токен из куки
                if (token == null) { return Redirect("/Account/Login"); }
                bool check = await _apiRequests.PersoneAdd(persone, token);
                return Redirect("/Persone/GetPersones");
            }
            catch (HttpResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Redirect("/Account/Login");
                }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                    return View();
                }
            }
        }
        /// <summary>
        /// Редактирование записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> PersoneEdit(int id)
        {
            var token = Request.Cookies["jwt"];//достаем токен из куки
            if (token == null) { return Redirect("/Account/Login"); }
            Persone persone = await _apiRequests.GetOnePersoneById(id, token);
            return View(persone);          
        }
        /// <summary>
        /// Редактирование записи
        /// </summary>
        /// <param name="persone"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> PersoneEdit(Persone persone)
        {           
            try
            {
                var token = Request.Cookies["jwt"];
                if (token == null) { return Redirect("/Account/Login"); }
                bool check = await _apiRequests.PersoneEdit(persone, token);
                return Redirect("/Persone/GetPersones");
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
        public async Task<IActionResult> PersoneDelete(int id)
        {
            try
            {
                var token = Request.Cookies["jwt"];
                if (token == null) { return Redirect("/Account/Login"); }
                bool check = await _apiRequests.PersoneDelete(id, token);
                return Redirect("/Persone/GetPersones");
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

    }
}
