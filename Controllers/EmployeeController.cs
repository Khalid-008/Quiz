using Microsoft.AspNetCore.Mvc;
using Quiz.Models;
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

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Employee> list = unitOfWork.EmployeeRepository.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            ViewBag.StoresList = unitOfWork.StoreRepository.GetAll().Select(x => x.Id).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.StoresList = unitOfWork.StoreRepository.GetAll().Select(x => x.Id).ToList();

                return View("AddEmployee", model);
            }

            model.Created_date = DateTime.Now.Date;
            unitOfWork.EmployeeRepository.Add(model);
            return RedirectToAction("index", "Employee");
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int Id)
        {
            ViewBag.StoresList = unitOfWork.StoreRepository.GetAll().Select(x => x.Id).ToList();
            var Employee = unitOfWork.EmployeeRepository.GetAll().FirstOrDefault(x => x.Id == Id);
            return View(Employee);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.StoresList = unitOfWork.StoreRepository.GetAll().Select(x => x.Id).ToList();

                return View("UpdateEmployee", model);
            }
            unitOfWork.EmployeeRepository.Update(model);
            return RedirectToAction("index", "Employee");
        }
        [HttpGet]
        public IActionResult DeleteEmployee(int Id)
        {
            var Employee = unitOfWork.EmployeeRepository.GetAll().FirstOrDefault(x => x.Id == Id);
            unitOfWork.EmployeeRepository.Delete(Employee);
            return RedirectToAction("index", "Employee");
        }
    }
}
