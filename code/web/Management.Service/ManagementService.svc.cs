using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAL.Model.ManagementCenter;
using Management.Service.Model;
using System.Transactions;
using Business.Common.ManagementCenter;
using Management.Service.AsiTech.Services.Notification;
using Management.Service.Notification;

namespace Management.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ManagementService : ICustomerOrderService, ICustomerService, ISuppliersService, IProductService
    {
        #region ICustomerOrderService

        [TransactionFlow(TransactionFlowOption.Allowed)]
        public void ChangeOrderState(OrderKeyModel orderModel, OrderState state)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                using (var mappers = new ManagementDataMapperContainer())
                {
                    var orderMapper = mappers.CustomerOrderMapper;

                    var order = orderMapper.Query().SingleOrDefault(o => o.ProductId == orderModel.ProductCode && o.CustomerId == orderModel.CustomerId && o.OrderDate == orderModel.OrderDate);

                    if (order == null)
                    {
                        throw new ArgumentException("Order doesn't exist!");
                    }

                    order.State = (int)state;
                    orderMapper.Update(order);

                    NotificationHelper.NotifyOrderChangedState(mappers.CustomerMapper.Get(orderModel.CustomerId),
                                                               mappers.ProductMapper.Get(orderModel.ProductCode),
                                                               state.ToString());

                }

                transaction.Complete();
            }
        }

        public OrderModel[] AllOrders()
        {
            using (var mappers = new ManagementDataMapperContainer())
            {
                var orderMapper = mappers.CustomerOrderMapper;

                return orderMapper.Query().Select(o =>
                    new OrderModel
                    {
                        ProductCode = o.ProductId,
                        CustomerId = o.CustomerId,
                        OrderDate = o.OrderDate,
                        Quantity = o.OrderAmount.Value,
                        State = o.State
                    }).ToArray();
            }
        }

        public OrderModel GetOrder(OrderKeyModel orderModel)
        {
            using (var mappers = new ManagementDataMapperContainer())
            {
                var orderMapper = mappers.CustomerOrderMapper;

                return orderMapper.Query()
                    .Select(o =>
                        new OrderModel
                        {
                            ProductCode = o.ProductId,
                            CustomerId = o.CustomerId,
                            OrderDate = o.OrderDate,
                            Quantity = o.OrderAmount.Value,
                            State = o.State
                        })
                    .SingleOrDefault(o => o.ProductCode == orderModel.ProductCode && o.CustomerId == orderModel.CustomerId && o.OrderDate == orderModel.OrderDate);
            }
        }
        #endregion

        #region ICustomerService

        [TransactionFlow(TransactionFlowOption.Allowed)]
        public void CreateCustomer(CreateCustomerModel model)
        {
            using (var mappers = new ManagementDataMapperContainer())
            {
                var customerMapper = mappers.CustomerMapper;

                customerMapper.Create(new Customer
                {
                    Address = model.Address,
                    Email = model.EmailAddress
                });
            }
        }

        [TransactionFlow(TransactionFlowOption.Allowed)]
        public void RemoveCustomer(RemoveCustomerModel model)
        {
            using (var mappers = new ManagementDataMapperContainer())
            {
                var customerMapper = mappers.CustomerMapper;

                customerMapper.Delete(model.CustomerNumber);
            }
        }

        public CustomerModel[] AllCustomers()
        {
            using (var mappers = new ManagementDataMapperContainer())
            {
                var customerMapper = mappers.CustomerMapper;

                return customerMapper.Query().Select
                (c => new CustomerModel
                    {
                        Number = c.Id,
                        Address = c.Address,
                        EmailAddress = c.Email
                    }
                ).ToArray();
            }
        }

        #endregion

        #region ISuppliersService

        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        public void OrderReceived(OrderProductModel model)
        {
            using (var mappers = new ManagementDataMapperContainer())
            {
                var order = mappers.SupplierOrderMapper.Query().FirstOrDefault(
                    o => o.ProductId.Equals(model.ProductCode) && o.SupplierId.Equals(model.Supplier));

                if (order == null)
                    return;

                mappers.SupplierOrderMapper.Delete(order);

                var product = mappers.ProductMapper.Get(model.ProductCode);

                if (product == null)
                    return;

                product.AvailableAmount += order.OrderAmount;

                mappers.ProductMapper.Update(product);

            }
        }

        [TransactionFlow(TransactionFlowOption.Allowed)]
        public void OrderProduct(OrderProductModel model)
        {
            using (var mappers = new ManagementDataMapperContainer())
            {
                var supplierOrderMapper = mappers.SupplierOrderMapper;

                supplierOrderMapper.Create(new SupplierOrder
                {
                    ProductId = model.ProductCode,
                    SupplierId = model.Supplier,
                    OrderAmount = model.Quantity,
                    OrderDate = DateTime.Now
                });
            }
        }

        public SupplierModel[] AllSuppliers()
        {
            using (var mappers = new ManagementDataMapperContainer())
            {
                var supplierMapper = mappers.ProductSupplierMapper;

                return supplierMapper.Query().Select(
                    s => new SupplierModel
                    {
                        Id = s.Id,
                        Address = s.Address,
                        Name = s.Name
                    }
                ).ToArray();
            }
        }
        #endregion

        #region IProductService

        public ProductModel[] AllProducts()
        {
            using (var mappers = new ManagementDataMapperContainer())
            {
                var productMapper = mappers.ProductMapper;

                return productMapper.Query().Select(p =>
                    new ProductModel
                    {
                        Code = p.Id,
                        Name = p.Name,
                        Quantity = p.AvailableAmount,
                        Supplier = p.SupplierId
                    }).ToArray();
            }
        }

        public ProductModel[] ProductsFrom(int supplierId)
        {
            using (var mappers = new ManagementDataMapperContainer())
            {
                var productMapper = mappers.ProductMapper;

                return productMapper.Query().Where(p => p.SupplierId == supplierId)
                    .Select(p => new ProductModel
                        {
                            Code = p.Id,
                            Name = p.Name,
                            Quantity = p.AvailableAmount,
                            Supplier = p.SupplierId
                        }).ToArray();
            }
        }

        #endregion
    }
}
