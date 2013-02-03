using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Access;
using DAL.EntityFramework.Services.Management;
using DAL.Model.ManagementCenter;

namespace Business.Common.ManagementCenter
{
    public class ManagementDataMapperContainer : MapperContainerBase<ManagementCenterContext>
    {

        public ManagementDataMapperContainer()
        {
            _productMapper = new ManagementCenterProductMapper(DbContext);
            _customerMapper = new ManagementCenterCustomerMapper(DbContext);
            _productSupplierMapper = new ManagementCenterProductSupplierMapper(DbContext);
            _supplierOrderMapper = new ManagementCenterSupplierOrderMapper(DbContext);
            _customerOrderMapper = new ManagementCenterCustomerOrderMapper(DbContext);
        }

        private readonly IProductMapper _productMapper;
        private readonly ICustomerMapper _customerMapper;
        private readonly IProductSupplierMapper _productSupplierMapper;
        private readonly ISupplierOrderMapper _supplierOrderMapper;
        private readonly ICustomerOrderMapper _customerOrderMapper;

        public IProductMapper ProductMapper { get { return VerifyDisposedAndReturnValue(_productMapper); } }
        public ICustomerMapper CustomerMapper { get { return VerifyDisposedAndReturnValue(_customerMapper); } }
        public IProductSupplierMapper ProductSupplierMapper { get { return VerifyDisposedAndReturnValue(_productSupplierMapper); } }
        public ISupplierOrderMapper SupplierOrderMapper { get { return VerifyDisposedAndReturnValue(_supplierOrderMapper); } }
        public ICustomerOrderMapper CustomerOrderMapper { get { return VerifyDisposedAndReturnValue(_customerOrderMapper); } }

    }
}
