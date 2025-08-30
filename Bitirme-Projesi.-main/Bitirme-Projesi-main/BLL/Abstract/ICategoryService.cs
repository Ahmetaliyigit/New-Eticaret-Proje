using Entity;
using Entity.Reposteries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface ICategoryService : IRepository<Category>
    {
        Task<List<Category>> GetCategoryWithProduct();
    }
}
