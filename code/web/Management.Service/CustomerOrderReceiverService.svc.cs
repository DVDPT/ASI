using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAL.Model.ManagementCenter;
using Management.Service.Model;

namespace Management.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CustomerOrderReceiverService : ICustomerOrderReceiverService
    {
        [OperationBehavior(TransactionAutoComplete = false,
                         TransactionScopeRequired = true
       )]
        public void HandleOrder(CustomerOrderModel order)
        {

        }
    }
}
