using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication.Module32.Models.Db;

namespace WebApplication.Module32.Controllers
{
    public class LogsController : Controller
    {
        private readonly IBlogRepository _repository;

        public LogsController(IBlogRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var requests = _repository.GetRequests().OrderByDescending(r => r.Date).ToList();
            return View(requests);
        }
    }
}
