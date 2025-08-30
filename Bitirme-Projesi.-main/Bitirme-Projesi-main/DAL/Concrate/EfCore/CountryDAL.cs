using DAL.Abstract;
using DAL.Concrate.EfCore.Context;
using DAL.EfCore;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrate.EfCore
{
    public class CountryDAL : Repository<Country> , ICountryDAL
    {
        private readonly DataContext context;

        public CountryDAL(DataContext dataContext) : base(dataContext)
        {
            context = dataContext;
        }

      
    }
}
