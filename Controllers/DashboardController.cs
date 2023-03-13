using Microsoft.AspNetCore.Mvc;
using Quiz.Repository.Infrastructure.Interface;

namespace Quiz.Controllers
{
    public class DashboardController : Controller
    {
        public readonly IUnitOfWork unitOfWork;
        public DashboardController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}