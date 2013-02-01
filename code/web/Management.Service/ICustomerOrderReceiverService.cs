using Management.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Management.Service
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ICustomerOrderReceiverService
    {
        [OperationContract(IsOneWay = true)]
        void HandleOrder(CreateOrderModel order);        
    }
}
