﻿using System;
using System.ServiceModel;
using System.Transactions;
using System.Linq;
using Business.Common.Error;
using Business.Common.OrdersCenter;
using DAL.Access;
using DAL.Model.Entities;
using DAL.Model.OrdersCenter;
using Ninject;
using Orders.Service.AsiTech.Services.Management;
using Orders.Service.AsiTech.Services.Notification;
using Orders.Service.Model;
using CustomerBase = DAL.Model.Entities.CustomerBase;
using Management.Service.Model;

namespace Orders.Service
{
    public class OrdersService : IOrdersService
    {


        [OperationBehavior]
        public void PlaceOrder(OrderModel order)
        {
            if (order.Quantity <= 0)
                throw new NotSupportedException();

            using (var transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                CustomerBase customer;
                ProductBase prod;
                using (var mappers = new OrdersDataMapperContainer())
                {
                    prod = EnsureProductExistance(mappers.ProductMapper, order.ProductCode);
                   
                    customer = EnsureCustomerExistance(mappers.CustomerMapper, order.CustomerId);


                    using (var orderService = new CustomerOrderReceiverServiceClient())
                    {
                        orderService.HandleOrder(new CustomerOrderModel
                                                     {
                                                         CustomerId = order.CustomerId,
                                                         ProductCode = order.ProductCode,
                                                         Quantity = order.Quantity
                                                     });
                    }
                    try
                    {
                        using (var notification = new NotificationServiceClient())
                        {
                            notification.SendEmail(customer.Email, "Your order was .");
                        }
                    }
                    catch 
                    {
                        // if it fails ignore.
                    }

                    transaction.Complete();
                }              

            }
        }

        private CustomerBase EnsureCustomerExistance(ICustomerMapper mapper, int customerId)
        {
            var customer = mapper.Get(customerId);

            if (customer == null)
                throw new CustomerNotFoundException(customerId);

            return customer;
        }

        private ProductBase EnsureProductExistance(IProductMapper mapper, int id)
        {
            var product = mapper.Get(id);

            if (product == null)
                throw new ProductNotFoundException(id);

            return product;
        }


        public ProductModel[] ListProducts()
        {
            using (var mappers = new OrdersDataMapperContainer())
            {
                var productsMapper = mappers.ProductMapper;

                return productsMapper.Query()
                    .Select(p => new ProductModel
                    {
                        Code = p.Id,
                        Name = p.Name,
                        Quantity = p.AvailableAmount,
                        Supplier = p.SupplierId
                    }).ToArray();
            } 
        }
    }
}
