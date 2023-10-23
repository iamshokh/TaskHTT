using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskHTT.DataLayer.EfClasses;
using TaskHTT.DataLayer.EfCode;

namespace TaskHTT.ServiceLayer.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly EfCoreContext _context;
        public CategoryService(EfCoreContext context)
        {
            _context = context;
        }

        public void Create(CategoryDto dto)
        {
            var newCategory = new Category
            {
                //CategoryName = cate
            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if(category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            else
                throw new Exception("Категория не найдена");
        }

        public List<Category> GetList()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }

        public void Update(CategoryDto dto)
        {
            var updateCategory = new Category
            {
                ///
            };
            _context.Update(updateCategory);
            _context.SaveChanges();
        }
    }
}
