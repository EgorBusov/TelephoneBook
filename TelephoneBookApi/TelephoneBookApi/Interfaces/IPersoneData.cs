using TelephoneBookApi.Models;

namespace TelephoneBookApi.Interfaces
{
    /// <summary>
    /// Взаимодействие с бд касаемо Persone
    /// </summary>
    public interface IPersoneData
    {
        /// <summary>
        /// получение всех записей
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Persone>> GetPersones();
        /// <summary>
        /// Получение полной инф о записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Persone> GetOnePersone(int id);
        /// <summary>
        /// Добавление записи
        /// </summary>
        /// <param name="persone"></param>
        Task AddPersone(Persone persone);
        /// <summary>
        /// удаление записи
        /// </summary>
        /// <param name="personeId"></param>
        Task DeletePersone(int personeId);
        /// <summary>
        /// редактирование записи
        /// </summary>
        /// <param name="persone"></param>
        Task EditPersone(Persone persone);
        /// <summary>
        /// сохранение бд
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
