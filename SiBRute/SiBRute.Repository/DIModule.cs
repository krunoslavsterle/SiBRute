using Ninject.Modules;
using SiBRute.Repository.Common;

namespace SiBRute.Repository
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {  
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IRoutesRepository>().To<RoutesRepository>();
        }
    }
}
