using OrdersService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using Ninject;
using DAL.Access.OrdersCenter;

namespace OrdersService
{
    public class OrdersService : IOrdersService
    {
        public OrdersService()
        {

        }

        public void PlaceOrder(OrderModel order)
        {

        }
    }
}
