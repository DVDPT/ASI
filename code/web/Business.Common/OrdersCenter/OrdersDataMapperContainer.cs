using DAL.Access;
using DAL.EntityFramework.Services.Orders;
using DAL.Model.OrdersCenter;

namespace Business.Common.OrdersCenter
{
    public class OrdersDataMapperContainer : MapperContainerBase<OrdersCenterContext>
    {
        public OrdersDataMapperContainer()
        {
            _productMapper = new OrdersCenterProductMapper(DbContext);
            _customerMapper = new OrdersCenterCustomerMapper(DbContext);
        }

        private readonly IProductMapper _productMapper;
        private readonly ICustomerMapper _customerMapper;

        public IProductMapper ProductMapper { get { return VerifyDisposedAndReturnValue(_productMapper); } }
        public ICustomerMapper CustomerMapper { get { return VerifyDisposedAndReturnValue(_customerMapper); } }  
    }
}
