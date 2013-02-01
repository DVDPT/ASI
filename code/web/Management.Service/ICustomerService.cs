using Management.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Management.Service
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract(IsOneWay = true)]
        void CreateCustomer(CreateCustomerModel model);

        [OperationContract(IsOneWay = true)]
        void RemoveCustomer(RemoveCustomerModel model);

        [OperationContract()]
        IEnumerable<CustomerModel> AllCustomers();
    }
}
