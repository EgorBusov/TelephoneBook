using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using TelephoneBookApi.Interfaces;
using TelephoneBookApi.Models;

namespace TelephoneBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersoneController : ControllerBase
    {
        private readonly IPersoneData personeData;
        public PersoneController(IPersoneData personeData)
        {
            this.personeData = personeData;
        }

        /// <summary>
        /// Получение всех записей
        /// </summary>
        /// <returns></returns>
        [Route("GetPersones")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Persone>> GetPersones()
        {
            return await personeData.GetPersones();
        }

        /// <summary>
        /// Получение полной инф о записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetOnePersoneById/{id}")]
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<Persone> GetOnePersoneById(int id)
        {
            Persone persone = await personeData.GetOnePersone(id);
            return persone;
        }

        /// <summary>
        /// Добавление записи
        /// </summary>
        /// <param name="persone"></param>
        /// <returns></returns>
        [Route("PersoneAdd")]
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task PersoneAdd(Persone persone)
        {            
            await personeData.AddPersone(persone);
        }
        /// <summary>
        /// Редактирование записи
        /// </summary>
        /// <param name="id"></param>
        /// <param name="persone"></param>
        /// <returns></returns>
        [Route("EditPersone")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task EditPersone([FromBody] Persone persone)
        {
            await personeData.EditPersone(persone);
        }
        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DeletePersone/{id}")]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeletePersone(int id)
        {
            await personeData.DeletePersone(id);
        }
    }
}

