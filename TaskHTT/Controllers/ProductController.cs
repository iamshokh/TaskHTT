using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskHTT.DataLayer.EfClasses;
using TaskHTT.ServiceLayer.CategoryService;
using TaskHTT.ServiceLayer.ProductService;

namespace TaskHTT.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Create()
        //{
        //    var dto = new ProductDto();
        //    dto.CategoryList = _categoryService.GetList().Select(a => new SelectListItem { Text = a.CategoryName, Value = a.Id.ToString(), Selected = a.Id == dto.CategoryId }).ToList();
        //    return View(dto);
        //}

        public IActionResult Create(ProductDto dto)
        {
            dto.CategoryList= _categoryService.GetList().Select(a => new SelectListItem { Text = a.CategoryName, Value = a.Id.ToString(), Selected = a.Id == dto.CategoryId}).ToList();
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var result = _productService.Create(dto);
            if (result)
            {
                TempData["msg"] = "Created Successfully";
                return RedirectToAction(nameof(GetList));
            }
            TempData["msg"] = "Error has occured on server side";
            return View(dto);
        }

        public IActionResult Update(int id)
        {
            var record = _productService.GetById(id);
            record.CategoryList = _categoryService.GetList().Select(a => new SelectListItem { Text = a.CategoryName, Value = a.Id.ToString(), Selected = a.Id == record.CategoryId }).ToList();
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(UpdateProductDto dto)
        {
            dto.CategoryList = _categoryService.GetList().Select(a => new SelectListItem { Text = a.CategoryName, Value = a.Id.ToString(), Selected = a.Id == dto.CategoryId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var result = _productService.Update(dto);
            if (result)
            {
                return RedirectToAction("GetList");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(dto);
        }

        public IActionResult Delete(int id)
        {

            var result = _productService.Delete(id);
            return RedirectToAction("GetList");
        }

        public IActionResult GetList()
        {

            var data = _productService.GetList();
            return View(data);
        }
    }
}
