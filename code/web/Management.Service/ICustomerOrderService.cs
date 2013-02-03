using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAL.Model.ManagementCenter;
using Management.Service.Model;
using Business.Common.ManagementCenter;

namespace Management.Service
{
    [ServiceContract]
    public interface ICustomerOrderService
    {
        [OperationContract(IsOneWay = true)]
        void ChangeOrderState(OrderKeyModel order, OrderState state);

        [OperationContract]
        OrderModel[] AllOrders();

        [OperationContract]
        OrderModel GetOrder(OrderKeyModel orderModel);
    }


    
}
