using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Module32.Models.Db;

namespace WebApplication.Module32
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task AddRequest(Request request); // Добавление записи о запросе
        Task<List<Request>> GetRequests(); // Получение истории запросов
    }
}
