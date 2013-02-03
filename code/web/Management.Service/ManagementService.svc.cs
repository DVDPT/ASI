using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Business.Common.Notification;
using DAL.Model.ManagementCenter;
using Management.Service.Model;
using System.Transactions;
using Business.Common.ManagementCenter;
using Management.Service.AsiTech.Services.Notification;

namespace Management.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ManagementService : ICustomerOrderReceiverService, ICustomerOrderService, ICustomerService, ISuppliersService
    {
        #region ICustomerOrderReceiverService
        [OperationBehavior(TransactionAutoComplete = true,
                         TransactionScopeRequired = true
        )]
        public void HandleOrder(CreateOrderModel orderModel)
        {
            using (var mappers = new ManagementDataMapperContainer())
            {
                var product = mappers.ProductMapper.Get(orderModel.ProductCode);
                var customer = mappers.CustomerMapper.Get(orderModel.CustomerId);

                if (product.AvailableAmount < orderModel.Quantity)
                {
                    //
                    //  Order can't be satisfied, notify the user.
                    //
                    NotificationHelper.NotifyOrderCantBeHeld(customer, product);
                    return;
                }


                product.AvailableAmount -= orderModel.Quantity;
                mappers.ProductMapper.Update(product);

                var customerOrderMapper = mappers.CustomerOrderMapper;

                customerOrderMapper.Create(new CustomerOrder
                {
                    CustomerId = orderModel.CustomerId,
                    ProductId = orderModel.ProductCode,
                    OrderAmount = orderModel.Quantity,
                    OrderDate = DateTime.Now,
                    State = (int)OrderState.Processing
                });

                NotificationHelper.NotifyOrderIsBeingProcessed(customer, product);
            }

        }



        #endregion

        #region ICustomerOrderService

        [TransactionFlow(TransactionFlowOption.Allowed)]
        public void ChangeOrderState(OrderModel orderModel, OrderState state)
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
    }
}
