using Microsoft.AspNetCore.Mvc;
using Quiz.Repository.Infrastructure.Interface;

namespace Quiz.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly IUnitOfWork unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
