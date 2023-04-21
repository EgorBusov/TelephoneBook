using System.Text.Json;
using System.Text;
using TelephoneBookWeb.ModelsAuth;
using TelephoneBookWeb.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Azure.Core;
using System.Net.Http;
using System.Net;
using System.Web.Http;

namespace TelephoneBookWeb.ApiInteraction
{
    public class ApiRequests
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public ApiRequests(HttpClient client, string baseUrl)
        {
            _httpClient = client;
            _baseUrl = baseUrl;
        }
        /// <summary>
        /// Залогинивание
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<TokenResponse> LoginRequest(UserModel user)
        {

            var json = JsonSerializer.Serialize(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUrl}/Account/Login", data);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                var token = JsonSerializer.Deserialize<TokenResponse>(responseJson);
                return token;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else
            {
                throw new HttpResponseException(response.StatusCode);
            }
        }
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<TokenResponse> RegisterRequest(UserModel user)
        {
            var json = JsonSerializer.Serialize(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUrl}/Account/Register", data );

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                var token = JsonSerializer.Deserialize<TokenResponse>(responseJson);
                return token;
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
            else
            {
                throw new HttpResponseException(response.StatusCode);
            }
        }
        /// <summary>
        /// Получение всех записей из telephoneBook
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Persone>> GetPersones()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/Persone/GetPersones");

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase // имена свойств должны быть в формате camelCase
                };
                var persones = await JsonSerializer.DeserializeAsync<IEnumerable<Persone>>(responseStream, options);
                return persones;
            }
            return null;
        }
        /// <summary>
        /// Получение полной инф о записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Persone> GetOnePersoneById(int id, string token)
        {                      
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{_baseUrl}/Persone/GetOnePersoneById/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase // имена свойств должны быть в формате camelCase
                };
                var persone = await JsonSerializer.DeserializeAsync<Persone>(responseStream, options);
                return persone;
            }
           
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else
            {
                throw new HttpResponseException(response.StatusCode);
            }
        }
        /// <summary>
        /// Добавление записи
        /// </summary>
        /// <param name="persone"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> PersoneAdd(Persone persone, string token)
        {
            string body = JsonSerializer.Serialize(persone);
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsync($"{_baseUrl}/Persone/PersoneAdd", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else
            {
                throw new HttpResponseException(response.StatusCode);
            }
        }
        /// <summary>
        /// Редактирование записи
        /// </summary>
        /// <param name="persone"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> PersoneEdit(Persone persone, string token)
        {
            string body = JsonSerializer.Serialize(persone);
            var content = new StringContent(body,Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsync($"{_baseUrl}/Persone/EditPersone", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else if(response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
            else
            {
                throw new HttpResponseException(response.StatusCode);
            }
        }
        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> PersoneDelete(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/Persone/DeletePersone/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
            else
            {
                throw new HttpResponseException(response.StatusCode);
            }
        }
        /// <summary>
        /// Получение всех user
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserModel>> GetUsers(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{_baseUrl}/Account/GetUsers");
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase // имена свойств должны быть в формате camelCase
                };
                var users = await JsonSerializer.DeserializeAsync<IEnumerable<UserModel>>(responseStream, options);
                return users;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
            else
            {
                throw new HttpResponseException(response.StatusCode);
            }
        }
        /// <summary>
        /// Удаление user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        public async Task<bool> DeleteUser(string userName, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/Account/DeleteUser/{userName}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if(response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
            else
            {
                throw new HttpResponseException(response.StatusCode);
            }
        }
    }
}
