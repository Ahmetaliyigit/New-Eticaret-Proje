using DAL.Abstract;
using DAL.Concrate.EfCore.Context;
using DAL.EfCore;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrate.EfCore
{
    public class CartDAL : Repository<Cart>, ICartDAL
    {
        private readonly DataContext context;
        public CartDAL(DataContext datacontext) : base(datacontext)
        {
            context = datacontext;
        }

        public async Task<Cart> GetCartWithProductAsync(Expression<Func<Cart, bool>> filter = null)
        {
            return context.Carts.Include(i => i.Products).FirstOrDefault(filter);
        }
    }
}
