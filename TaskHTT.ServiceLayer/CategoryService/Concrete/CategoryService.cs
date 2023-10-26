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

        public UpdateCategoryDto GetById(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            var result = new UpdateCategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Title = category.Title,
            };
            return result;
        }

        public List<Category> GetList()
        {
            var categories = _context.Categories.Where(c => c.StateId == StateIdConst.ACTIVE).ToList();
            return categories;
        }

        public List<Category> Search(string search)
        {
            var categories = _context.Categories.Where(p => p.CategoryName.ToLower().Contains(search.ToLower()) && p.StateId == StateIdConst.ACTIVE);
            return categories.ToList();
        }

        public bool Update(UpdateCategoryDto dto)
        {
            try
            {
                var updateCategory = new Category
                {
                    Id = dto.Id,
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
