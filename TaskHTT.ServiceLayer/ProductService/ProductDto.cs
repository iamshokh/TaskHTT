using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskHTT.ServiceLayer.ProductService
{
    public class ProductDto
    {
        public string ProductName { get; set; } 
        public string Title { get; set; }
        public int CategoryId { get; set; }


        [NotMapped]
        public List<SelectListItem>? CategoryList { get; set; }
    }
}
