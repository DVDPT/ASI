using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using DAL.Interfaces;

namespace DAL.EntityFramework
{
    public class EFModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IClientService>()
                .To<ClientService>()
                .InRequestScope();

            Bind<IOrderService>()
                .To<OrderService>()
                .InRequestScope();

            Bind<IProductService>()
                .To<ProductService>()
                .InRequestScope();

            Bind<ISupplierService>()
                .To<SupplierService>()
                .InRequestScope();
        }
    }
}
