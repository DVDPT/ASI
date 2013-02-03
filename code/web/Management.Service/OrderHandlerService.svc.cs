using Business.Common.ManagementCenter;
using Business.Common.Notification;
using DAL.Model.ManagementCenter;
using Management.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Management.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrderHandlerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OrderHandlerService.svc or OrderHandlerService.svc.cs at the Solution Explorer and start debugging.
    public class OrderHandlerService : ICustomerOrderReceiverService
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
    }
}
