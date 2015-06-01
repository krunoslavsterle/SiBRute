using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiBRute.DAL
{
    public class DIModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IRoutesDbContext>().To<RoutesDbContext>();
        }
    }
}
