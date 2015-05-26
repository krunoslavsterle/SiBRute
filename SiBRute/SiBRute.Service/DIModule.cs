using Ninject.Modules;
using SiBRute.Service.Common;

namespace SiBRute.Service
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRoutesService>().To<RoutesService>();
        }
    }
}
