using BLL.Abstract;
using DAL.Abstract;
using DAL.EfCore;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductDAL dal;

        public ProductService(IProductDAL Dal)
        {
            dal = Dal;
        }

        public async Task CreateAsync(Product entity)
        {
            await dal.CreateAsync(entity);
        }

        public async Task UpdateAsync(Product entity)
        {
            await dal.UpdateAsync(entity);
        }

        public Task DeleteAsync(Product category)
        {
            return dal.DeleteAsync(category);
        }

        public async Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null)
        {
            if (filter != null)
            {
                return await dal.GetAllAsync(filter);
            }

            return await dal.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int Id)
        {
            return await dal.GetByIdAsync(Id);
        }

        public async Task SaveChanges()
        {
            await dal.SaveChanges();
        }

        public Task DeleteByIdAsync(int Id)
        {
            return dal.DeleteByIdAsync(Id);
        }

        public async Task<List<Product>> GetProuctsWithCategoryGenderColorAsync(Expression<Func<Product, bool>> filter = null)
        {
            return await dal.GetProuctsWithCategoryGenderColorAsync(filter);
        }

        public Task<Product> GetOneAsync(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
