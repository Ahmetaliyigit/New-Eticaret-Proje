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
    public class ContryService : ICountryService
    {
        private readonly ICountryDAL dal;

        public ContryService(ICountryDAL countryDAL)
        {
            dal = countryDAL;
        }

        public async Task CreateAsync(Country entity)
        {
            await dal.CreateAsync(entity);
        }

        public async Task DeleteAsync(Country entity)
        {
            await dal.DeleteAsync(entity);
        }


        public async Task<Country> GetByIdAsync(int Id)
        {
            return await dal.GetByIdAsync(Id);
        }

        public async Task SaveChanges()
        {
            await dal.SaveChanges();
        }

        public async Task UpdateAsync(Country entity)
        {
            await dal.UpdateAsync(entity);
        }

        public Task DeleteByIdAsync(int Id)
        {
            return dal.DeleteByIdAsync(Id);
        }

        public async Task<List<Country>> GetAllAsync(Expression<Func<Country, bool>> filter = null)
        {
            return await dal.GetAllAsync(filter);
        }

        public Task<Country> GetOneAsync(Expression<Func<Country, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
