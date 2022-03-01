using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Infrastructure.Abstract;
using Infrastructure.Concrete;
using Ninject.Modules;
using System.Data.Entity;


namespace Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            #region Infrastructure
            Bind<ICalculatorSoapService>().To<CalculatorSoapManager>().InSingletonScope();
            #endregion

            #region Business
            Bind<ICalculatorService>().To<CalculatorManager>().InSingletonScope();
            #endregion

            #region DAL
            Bind<ICalculatorDal>().To<EfCalculatorDal>().InSingletonScope();
            Bind<DbContext>().To<CalculatorDbContext>();
            #endregion
        }
    }
}