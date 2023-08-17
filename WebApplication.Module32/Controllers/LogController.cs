using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks; // Не забудьте добавить это

namespace WebApplication.Module32.Controllers
{
    public class LogsController : Controller
    {
        private readonly IBlogRepository _repository;

        public LogsController(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index() // Сделал метод асинхронным
        {
            var requests = await _repository.GetRequests();
            var orderedRequests = requests.OrderByDescending(r => r.Date).ToList();
            return View(orderedRequests);
        }
    }
}
