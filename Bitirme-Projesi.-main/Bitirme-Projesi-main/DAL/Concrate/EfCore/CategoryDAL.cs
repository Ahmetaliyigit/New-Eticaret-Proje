using DAL.Abstract;
using DAL.Concrate.EfCore.Context;
using Entity;
using Entity.Reposteries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EfCore
{
    public class CategoryDAL : Repository<Category>, ICategoryDAL
    {
        private readonly DataContext context;

        public CategoryDAL(DataContext contexta) : base(contexta)
        {
            context = contexta;
        }

        public async Task<List<Category>> GetCategoryWithProduct()
        {
           return await context.Categories.Include(c => c.Products).ToListAsync();
        }
    }
}
