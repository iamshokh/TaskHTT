using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskHTT.DataLayer.EfClasses;

namespace TaskHTT.ServiceLayer.CategoryService
{
    public interface ICategoryService
    {
        List<Category> GetList();
        UpdateCategoryDto GetById(int id);
        bool Create(CategoryDto dto);
        bool Update(UpdateCategoryDto dto);
        bool Delete(int id);
        List<Product> GetByCategoryId(int id);

        List<Category> Search(string search);
    }
}
