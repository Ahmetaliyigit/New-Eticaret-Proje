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
            return  context.Carts.Include(i => i.CartProducts).FirstOrDefault(filter);
        }

        public async Task CreateAsync(Cart cart)
        {
            // garanti: identity conflict olmasın
            cart.Id = 0; // zorunlu değil ama güvenlik için
            await context.Carts.AddAsync(cart);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cart cart)
        {
            // DB'den takip edilen versiyonunu al ve sil
            var tracked = await context.Carts
                .Include(c => c.CartProducts)
                .FirstOrDefaultAsync(c => c.Id == cart.Id);

            if (tracked != null)
            {
                context.Carts.Remove(tracked);
                await context.SaveChangesAsync();
            }

            // Uygulama tarafında referansı temizle
            // (caller: Program.OnlineUser)
        }
    }
}
