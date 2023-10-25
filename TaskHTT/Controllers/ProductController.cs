using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        //}

        public IActionResult Create(ProductDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }
            var result = _productService.Create(dto);
            if (result)
            {
                TempData["msg"] = "Created Successfully";
                return RedirectToAction(nameof(Create));
            }
            TempData["msg"] = "Error has occured on server side";
            return View(dto);
        }

        //public IActionResult Update(int id)
        //{

        //}

        [HttpPost]
        public IActionResult Update(ProductDto dto)
        {
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
