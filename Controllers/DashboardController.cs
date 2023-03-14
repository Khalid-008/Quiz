using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Enum;
using Quiz.Models;
using Quiz.Repository.Infrastructure.Interface;

namespace Quiz.Controllers
{
    public class DashboardController : Controller
    {
        public readonly IUnitOfWork unitOfWork;
        public readonly ApplicationDbContext context;
        public DashboardController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var EMP_STOR = context.Set<Store>().Include(x => x.Employee);
            var model = EMP_STOR.ToList();
            ViewBag.ActiveEmployee = unitOfWork.EmployeeRepository.GetAll().Where(x => x.Status == Status.Active.ToString()).Count();
            ViewBag.ActiveStore = unitOfWork.StoreRepository.GetAll().Where(x => x.Status == Status.Active.ToString()).Count();
            return View(model);
        }
    }
}