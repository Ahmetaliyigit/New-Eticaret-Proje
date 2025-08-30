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
    public class ColorService : IColorService
    {
        private readonly IColorDAL dal;

        public ColorService(IColorDAL dAL)
        {
            dal = dAL;
        }

        public async Task CreateAsync(Color entity)
        {
            await dal.CreateAsync(entity);
        }

        public async Task DeleteAsync(Color category)
        {
            await dal.DeleteAsync(category);
        }

        public async Task<List<Color>> GetAllAsync(Expression<Func<Color, bool>> filter = null)
        {
            return await dal.GetAllAsync(filter);
        }

        public Task<Color> GetByIdAsync(int Id)
        {
            return dal.GetByIdAsync(Id);
        }

        public async Task SaveChanges()
        {
            await dal.SaveChanges();
        }

        public async Task UpdateAsync(Color entity)
        {
            await dal.UpdateAsync(entity);
        }

        public Task DeleteByIdAsync(int Id)
        {
            return dal.DeleteByIdAsync(Id);
        }

        public Task<Color> GetOneAsync(Expression<Func<Color, bool>> filter = null)
        {
            return dal.GetOneAsync(filter);
        }
    }
}
