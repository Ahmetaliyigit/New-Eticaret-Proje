using DAL.Abstract;
using DAL.Concrate.EfCore.Context;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EfCore
{
    public class ProductDAL:Repository<Product> , IProductDAL
    {
        private readonly DataContext db;

        public ProductDAL(DataContext context) : base(context)
        {
            db = context;
        }

        public async Task<List<Product>> GetProuctsWithCategoryGenderColorAsync(Expression<Func<Product, bool>> filter = null)
        {
            var Products = db.Products.Include(i => i.Category).Include(i => i.Gender).Include(i => i.Color).AsQueryable();

            if (filter != null)
            {
                Products = Products.Where(filter);
            }

            return await Products.ToListAsync();
    
        }
    }
}


