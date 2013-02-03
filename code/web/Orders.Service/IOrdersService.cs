using System.ServiceModel;
using Business.Common.Error;
using Orders.Service.Model;
using Management.Service.Model;
using System.Collections.Generic;

namespace Orders.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOrdersService
    {
        [OperationContract]
        void PlaceOrder(OrderModel order);

        [OperationContract]
        ProductModel[] ListProducts();
    }
}
