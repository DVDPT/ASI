using DAL.Access.Common;
using DAL.Access.OrdersCenter;
using DAL.EntityFramework.Services.Orders;
using Ninject.Modules;
using Orders.Service.AsiTech.Services.Management;
using Orders.Service.AsiTech.Services.Notification;

namespace Orders.Service.Module
{
    public class OrderServiceModule : NinjectModule
    {
        public override void Load()
        {

            Bind<ICustomerOrderReceiverService>().To<CustomerOrderReceiverServiceClient>();
            Bind<INotificationService>().To<NotificationServiceClient>();
            Bind<ICustomerMapper>().To<OrdersCenterCustomerMapper>();
            Bind<IProductMapper>().To<OrdersCenterProductMapper>();
        }
    }
}