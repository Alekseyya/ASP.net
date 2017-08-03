using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.DAL.Repositories;
using WebStore.DAL.Repositories.Base;



namespace WebStore.Hosting.DI
{
    public class WcfNinjectModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}