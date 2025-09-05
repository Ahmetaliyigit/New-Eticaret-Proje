using DAL.Abstract;
using DAL.Concrate.EfCore.Context;
using DAL.EfCore;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrate.EfCore
{
    public class OrderDAL : Repository<Order>, IOrderDAL
    {
        private readonly DataContext context; 
        public OrderDAL(DataContext datacontext) : base(datacontext)
        {
            context = datacontext;
        }

        public async Task AddOrderWithProductsAsync(Order order, List<int> productIds)
        {
            foreach (var productId in productIds)
            {
                // EF zaten takip ediyor mu diye kontrol et
                var trackedProduct = context.Products.Local.FirstOrDefault(p => p.Id == productId);
                if (trackedProduct != null)
                {
                    // Eğer takip ediliyorsa bunu kullan
                    order.Products.Add(trackedProduct);
                }
                else
                {
                    // Eğer takip edilmiyorsa yeni oluştur ve attach et
                    var product = new Product { Id = productId };
                    context.Attach(product);
                    order.Products.Add(product);
                }
            }

            // Order'ı ekle ve kaydet
            context.Orders.Add(order);
            await context.SaveChangesAsync();
        }

    }
}
