using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskHTT.DataLayer.EfClasses;

namespace TaskHTT.ServiceLayer.ProductService
{
    public interface IProductService
    {
        List<Product> GetList();
        UpdateProductDto GetById(int id);
        bool Create(ProductDto dto);
        bool Update(UpdateProductDto dto);
        bool Delete(int id);
    }
}
