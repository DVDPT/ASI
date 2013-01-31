using System.ServiceModel;
using DAL.Access.Common;
using DAL.Access.OrdersCenter;
using Orders.Service.AsiTech.Services.Management;
using Orders.Service.AsiTech.Services.Notification;
using Orders.Service.Model;

namespace Orders.Service
{
    public class OrdersService : IOrdersService
    {
        private readonly ICustomerOrderReceiverService _customerOrderReceiverService;
        private readonly ICustomerMapper _customerMapper;
        private readonly IProductMapper _productMapper;
        private readonly INotificationService _notificationService;


        public OrdersService(
            ICustomerOrderReceiverService customerOrderReceiverService,
            INotificationService notificationService,
            ICustomerMapper customerMapper,
            IProductMapper productMapper
            )
        {
            _customerOrderReceiverService = customerOrderReceiverService;
            _customerMapper = customerMapper;
            _productMapper = productMapper;
            _notificationService = notificationService;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void PlaceOrder(OrderModel order)
        {

        }
    }
}
