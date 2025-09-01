using Entity;
using Entity.Reposteries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ICartDAL : IRepository<Cart>
    {
        Task<Cart> GetCartWithProductAsync(Expression<Func<Cart ,bool>> filter = null);
    }
}
