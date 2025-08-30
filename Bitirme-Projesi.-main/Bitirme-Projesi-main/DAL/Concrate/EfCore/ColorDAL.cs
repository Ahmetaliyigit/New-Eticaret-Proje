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
    public class ColorDAL:Repository<Color> , IColorDAL
    {
        private readonly DataContext context;

        public ColorDAL(DataContext db) : base(db)
        {
            context = db;
        }
    }
}
