using BLL.Abstract;
using DAL.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class CartService : ICartService
    {
        private readonly ICartDAL dal;

        public CartService(ICartDAL Dal)
        {
            dal = Dal;
        }

        public async Task CreateAsync(Cart entity)
        {
            await dal.CreateAsync(entity);
        }

        public async Task DeleteAsync(Cart entity)
        {
            await dal.DeleteAsync(entity);
        }


        public async Task<Cart> GetByIdAsync(int Id)
        {
            return await dal.GetByIdAsync(Id);
        }

        public async Task SaveChanges()
        {
            await dal.SaveChanges();
        }

        public async Task UpdateAsync(Cart entity)
        {
            await dal.UpdateAsync(entity);
        }

        public Task DeleteByIdAsync(int Id)
        {
            return dal.DeleteByIdAsync(Id);
        }

        public async Task<List<Cart>> GetAllAsync(Expression<Func<Cart, bool>> filter = null)
        {
            return await dal.GetAllAsync(filter);
        }

        public Task<Cart> GetOneAsync(Expression<Func<Cart, bool>> filter = null)
        {
            return dal.GetOneAsync(filter);
        }

        public Task<Cart> GetCartWithProductAsync(Expression<Func<Cart, bool>> filter = null)
        {
            return dal.GetCartWithProductAsync(filter);
        }
    }
}
