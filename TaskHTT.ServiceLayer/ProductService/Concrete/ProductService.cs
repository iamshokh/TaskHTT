using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskHTT.Core;
using TaskHTT.DataLayer.EfClasses;
using TaskHTT.DataLayer.EfCode;

namespace TaskHTT.ServiceLayer.ProductService
{
    public class ProductService : IProductService
    {
        private readonly EfCoreContext _context;
        public ProductService(EfCoreContext context)
        {
            _context = context;
        }

        public UpdateProductDto GetById(int id)
        {
            var product = _context.Products.Include(p => p.Category).FirstOrDefault(c => c.Id == id);
            var result = new UpdateProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Title = product.Title,
                CategoryId = product.Category.Id,
            };
            return result;
        }

        public bool Create(ProductDto dto)
        {
            try
            {
                var newProduct = new Product
                {
                    ProductName = dto.ProductName,
                    Title = dto.Title,
                    CategoryId = dto.CategoryId,
                    StateId = StateIdConst.ACTIVE
                };
                _context.Products.Add(newProduct);
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
                var product = _context.Products.FirstOrDefault(c => c.Id == id);
                if (product == null)
                    return false;

                product.StateId = StateIdConst.PASSIVE;
                _context.Products.Update(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetList()
        {
            var products = _context.Products.Include(a => a.Category).Where(a => a.StateId == StateIdConst.ACTIVE).ToList();
            return products;
        }

        public bool Update(UpdateProductDto dto)
        {
            try
            {
                var updateProduct = new Product
                {
                    Id = dto.Id,
                    ProductName = dto.ProductName,
                    Title = dto.Title,
                    CategoryId = dto.CategoryId,
                    StateId = StateIdConst.ACTIVE
                };
                _context.Update(updateProduct);
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
