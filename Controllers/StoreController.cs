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
            try
            {
                IEnumerable<Store> list = unitOfWork.StoreRepository.GetAll();
                return View(list);
            }
            catch (Exception)
            {
                return View("~/Views/Error.cshtml");
            }
        }

        #region Add Store
        [HttpGet]
        public IActionResult AddStore()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("~/Views/Error.cshtml");
            }
        }

        [HttpPost]
        public IActionResult AddStore(Store model)
        {
            try
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
            catch (Exception)
            {
                return View("~/Views/Error.cshtml");
            }
        }
        #endregion

        #region Update Store
        [HttpGet]
        public IActionResult UpdateStore(int Id)
        {
            try
            {
                var Store = unitOfWork.StoreRepository.GetAll().FirstOrDefault(x => x.Id == Id);
                return View(Store);
            }
            catch (Exception)
            {
                return View("~/Views/Error.cshtml");
            }
        }

        [HttpPost]
        public IActionResult UpdateStore(Store model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.StoresList = unitOfWork.StoreRepository.GetAll().Select(x => x.Id).ToList();

                    return View("UpdateStore", model);
                }

                unitOfWork.StoreRepository.Update(model);
                return RedirectToAction("index", "Store");
            }
            catch (Exception)
            {
                return View("~/Views/Error.cshtml");
            }
        }
        #endregion
    }
}
