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
            try
            {
                var EmployeesInStores = context.Set<Store>().Include(x => x.Employee).ToList();
                ViewBag.ActiveEmployee = unitOfWork.EmployeeRepository.GetAll().Count(x => x.Status == Status.Active.ToString());
                ViewBag.ActiveStore = unitOfWork.StoreRepository.GetAll().Count(x => x.Status == Status.Active.ToString());
                return View(EmployeesInStores);
            }
            catch (Exception)
            {
                return View("~/Views/Error.cshtml");
            }
        }
    }
}