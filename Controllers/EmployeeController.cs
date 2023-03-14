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
            try
            {
                IEnumerable<Employee> list = unitOfWork.EmployeeRepository.GetAll();
                return View(list);
            }
            catch (Exception)
            {
                return View("~/Views/Error.cshtml");
            }
        }

        #region Add Employee
        [HttpGet]
        public IActionResult AddEmployee()
        {
            try
            {
                ViewBag.StoresList = unitOfWork.StoreRepository.GetAll().Select(x => x.Id).ToList();
                return View();
            }
            catch (Exception)
            {
                return View("~/Views/Error.cshtml");
            }
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee model)
        {
            try
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
            catch (Exception)
            {
                return View("~/Views/Error.cshtml");
            }
        }
        #endregion

        #region Update Employee
        [HttpGet]
        public IActionResult UpdateEmployee(int Id)
        {
            try
            {
                ViewBag.StoresList = unitOfWork.StoreRepository.GetAll().Select(x => x.Id).ToList();
                var Employee = unitOfWork.EmployeeRepository.GetAll().FirstOrDefault(x => x.Id == Id);
                return View(Employee);
            }
            catch (Exception)
            {
                return View("~/Views/Error.cshtml");
            }
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.StoresList = unitOfWork.StoreRepository.GetAll().Select(x => x.Id).ToList();

                    return View("UpdateEmployee", model);
                }
                unitOfWork.EmployeeRepository.Update(model);
                return RedirectToAction("index", "Employee");
            }
            catch (Exception)
            {
                return View("~/Views/Error.cshtml");
            }
        }
        #endregion

        #region Delete Employee
        [HttpGet]
        public IActionResult DeleteEmployee(int Id)
        {
            try
            {
                var Employee = unitOfWork.EmployeeRepository.GetAll().FirstOrDefault(x => x.Id == Id);

                if (Employee != null)
                    unitOfWork.EmployeeRepository.Delete(Employee);

                return RedirectToAction("index", "Employee");
            }
            catch (Exception)
            {
                return View("~/Views/Error.cshtml");
            }
        }
        #endregion
    }
}
