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
        void Create(CategoryDto dto);
        void Update(CategoryDto dto);
        void Delete(int id);

    }
}
