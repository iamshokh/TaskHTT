using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskHTT.Core;
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

        public bool Create(CategoryDto dto)
        {
            try
            {
                var newCategory = new Category
                {
                    CategoryName = dto.CategoryName,
                    Title = dto.Title,
                    StateId = StateIdConst.ACTIVE
                };
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(c => c.Id == id);
                if (category == null)
                    return false;

                category.StateId = StateIdConst.PASSIVE;
                _context.Categories.Update(category);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetByCategoryId(int id)
        {
            var products = _context.Products.Where(p => p.Id == id);
            if (products != null)
                return products.ToList();
            else return null;
        }

        public List<Category> GetList()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }

        public List<Category> Search(string search)
        {
            var categories = _context.Categories.Where(p => p.CategoryName.ToLower().Contains(search.ToLower()));
            return categories.ToList();
        }

        public bool Update(CategoryDto dto)
        {
            try
            {
                var updateCategory = new Category
                {
                    CategoryName = dto.CategoryName,
                    Title = dto.Title,
                    StateId = StateIdConst.ACTIVE
                };
                _context.Update(updateCategory);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
