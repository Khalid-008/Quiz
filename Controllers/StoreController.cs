using Microsoft.AspNetCore.Mvc;
using Quiz.Repository.Infrastructure.Interface;

namespace Quiz.Controllers
{
    public class StoreController : Controller
    {
        public readonly IUnitOfWork unitOfWork;
        public StoreController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
