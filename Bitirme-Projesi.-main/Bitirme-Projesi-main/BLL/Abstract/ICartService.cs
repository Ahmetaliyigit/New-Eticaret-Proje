using Entity;
using Entity.Reposteries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface ICartService : IRepository<Cart>
    {
        Task<Cart> GetCartWithProductAsync(Expression<Func<Cart, bool>> filter = null);
    }
}

