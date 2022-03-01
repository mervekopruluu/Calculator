using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Data.Entity;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCalculatorDal: EfEntityRepositoryBase<Calculator, CalculatorDbContext>, ICalculatorDal
    {
       
}
}