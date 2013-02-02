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
    public interface IProductService
    {
        [OperationContract]
        ProductModel[] AllProducts();

        [OperationContract]
        ProductModel[] ProductsFrom(int supplierId);
    }
}
