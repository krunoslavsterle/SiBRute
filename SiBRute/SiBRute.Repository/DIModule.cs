﻿using Ninject.Modules;
using SiBRute.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
