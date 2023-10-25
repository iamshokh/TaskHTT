using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHTT.ServiceLayer.ProductService
{
    public class ProductDto
    {
        public string ProductName { get; set; } 
        public string Title { get; set; }
        public int CategoryId { get; set; }
    }
}
