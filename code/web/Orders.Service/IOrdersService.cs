using System.ServiceModel;
using Orders.Service.Model;

namespace Orders.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOrdersService
    {
        [OperationContract]
        void PlaceOrder(OrderModel order);
    }
}
