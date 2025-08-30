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
    public class GenderService : IGenderService
    {
        private readonly IGenderDAL dal;
        public GenderService(IGenderDAL dAL)
        {
            dal = dAL;
        }

        public async Task CreateAsync(Gender entity)
        {
            await dal.CreateAsync(entity);
        }

        public async Task DeleteAsync(Gender entity)
        {
            await dal.DeleteAsync(entity);
        }

        public async Task<List<Gender>> GetAllAsync(Expression<Func<Gender, bool>> filter = null)
        {
            return await dal.GetAllAsync(filter);
        }

        public async Task<Gender> GetByIdAsync(int Id)
        {
            return await dal.GetByIdAsync(Id);
        }

        public async Task SaveChanges()
        {
            await dal.SaveChanges();
        }

        public async Task UpdateAsync(Gender entity)
        {
            await dal.UpdateAsync(entity);
        }

        public Task DeleteByIdAsync(int Id)
        {
            return dal.DeleteByIdAsync(Id);
        }

        public Task<Gender> GetOneAsync(Expression<Func<Gender, bool>> filter = null)
        {
            return dal.GetOneAsync(filter);
        }
    }
}
