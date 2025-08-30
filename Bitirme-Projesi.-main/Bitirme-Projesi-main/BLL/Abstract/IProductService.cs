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
    public interface IProductService : IRepository<Product>
    {
        Task<List<Product>> GetProuctsWithCategoryGenderColorAsync(Expression<Func<Product, bool>> filter = null);
    }
}
