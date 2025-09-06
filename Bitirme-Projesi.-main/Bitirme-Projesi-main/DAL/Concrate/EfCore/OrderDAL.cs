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


    }
}
