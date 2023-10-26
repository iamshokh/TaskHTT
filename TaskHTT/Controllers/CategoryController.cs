using Microsoft.AspNetCore.Mvc;
using TaskHTT.DataLayer.EfClasses;
using TaskHTT.ServiceLayer.CategoryService;

namespace TaskHTT.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public IActionResult GetList()
        {
            var data = _service.GetList();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            if (result)
            {
                TempData["msg"] = "Created Successfully";
                return RedirectToAction("GetList");
            }
            TempData["msg"] = "Error has occured on server side";
            return RedirectToAction("GetList");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var result = _service.Create(dto);
            if (result)
            {
                TempData["msg"] = "Created Successfully";
                return RedirectToAction(nameof(Create));
            }
            TempData["msg"] = "Error has occured on server side";
            return View(dto);
        }

        public IActionResult Update(int id)
        {
            var record = _service.GetById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var result = _service.Update(dto);
            if (result)
            {
                return RedirectToAction("GetList");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(dto);
        }
    }
}
