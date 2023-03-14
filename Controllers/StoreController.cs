using Microsoft.AspNetCore.Mvc;
using Quiz.Models;
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
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Store> list = unitOfWork.StoreRepository.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult AddStore()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStore(Store model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.StoresList = unitOfWork.StoreRepository.GetAll().Select(x => x.Id).ToList();

                return View("AddStore", model);
            }

            model.Created_date = DateTime.Now.Date;
            unitOfWork.StoreRepository.Add(model);
            return RedirectToAction("index", "Store");
        }

        [HttpGet]
        public IActionResult UpdateStore(int Id)
        {
            var Store = unitOfWork.StoreRepository.GetAll().FirstOrDefault(x => x.Id == Id);
            return View(Store);
        }
        [HttpPost]
        public IActionResult UpdateStore(Store model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.StoresList = unitOfWork.StoreRepository.GetAll().Select(x => x.Id).ToList();

                return View("UpdateStore", model);
            }

            unitOfWork.StoreRepository.Update(model);
            return RedirectToAction("index", "Store");
        }
    }
}
