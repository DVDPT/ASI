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
        [OperationContract]
        void OrderReceived(OrderProductModel model);

        [OperationContract]
        void OrderProduct(OrderProductModel model);

        [OperationContract]
        SupplierModel[] AllSuppliers();
    }
}
