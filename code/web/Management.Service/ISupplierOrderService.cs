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
    public interface ISuppliersService
    {
        [OperationContract(IsOneWay = true)]
        void OrderProduct(OrderProductModel model);

        IEnumerable<SupplierModel> AllSuppliers();
    }
}
