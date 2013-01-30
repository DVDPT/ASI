using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAL.Model.ManagementCenter;

namespace Management.Service
{
    [ServiceContract]
    public interface ICustomerOrderReceiverService
    {
        [OperationContract(IsOneWay = true)]
        void HandleOrder(CustomerOrder order);
    }


    
}
