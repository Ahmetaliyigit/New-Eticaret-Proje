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
    public class OrderService : IOrderService
    {
        private readonly IOrderDAL dal; 
        public OrderService(IOrderDAL order)
        {
            dal = order;
        }

        public async Task CreateAsync(Order entity)
        {
                await dal.CreateAsync(entity);
        }

        public async Task DeleteAsync(Order category)
        {
            await dal.DeleteAsync(category);
        }

        public async Task<List<Order>> GetAllAsync(Expression<Func<Order, bool>> filter = null)
        {
            return await dal.GetAllAsync(filter);
        }

        public Task<Order> GetByIdAsync(int Id)
        {
            return dal.GetByIdAsync(Id);
        }

        public async Task SaveChanges()
        {
            await dal.SaveChanges();
        }

        public async Task UpdateAsync(Order entity)
        {
            await dal.UpdateAsync(entity);
        }

        public Task DeleteByIdAsync(int Id)
        {
            return dal.DeleteByIdAsync(Id);
        }

        public Task<Order> GetOneAsync(Expression<Func<Order, bool>> filter = null)
        {
            return dal.GetOneAsync(filter);
        }

        public async Task AddOrderWithProductsAsync(Order order, List<int> productIds)
        {
            await dal.AddOrderWithProductsAsync(order, productIds);
        }
    }
}
