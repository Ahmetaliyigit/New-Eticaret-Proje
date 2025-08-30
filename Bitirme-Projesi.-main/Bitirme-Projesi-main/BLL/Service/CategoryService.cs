using BLL.Abstract;
using DAL.Abstract;
using DAL.EfCore;
using DAL.Migrations;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDAL dal;

        public CategoryService(ICategoryDAL dAL)
        {
            dal = dAL;
        }

        public async Task CreateAsync(Category entity)
        {
             await dal.CreateAsync(entity);
        }

        public async Task DeleteAsync(Category entity)
        {
            await dal.DeleteAsync(entity);
        }

        public Task DeleteByIdAsync(int Id)
        {
            return dal.DeleteByIdAsync(Id);
        }

        public async Task<List<Category>> GetAllAsync(Expression<Func<Category, bool>> filter = null)
        {
            return await dal.GetAllAsync(filter);
        }

        public async Task<Category> GetByIdAsync(int Id)
        {
            return await dal.GetByIdAsync(Id);
        }

        public async Task<List<Category>> GetCategoryWithProduct()
        {
            return await dal.GetCategoryWithProduct();
        }

        public async Task<Category> GetOneAsync(Expression<Func<Category, bool>> filter = null)
        {
            return await dal.GetOneAsync(filter);
        }

        public async Task SaveChanges()
        {
            await dal.SaveChanges();
        }

        public async Task UpdateAsync(Category entity)
        {
            await dal.UpdateAsync(entity);
        }
    }
}
