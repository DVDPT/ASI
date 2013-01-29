using OrdersService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAL.Interfaces;
using System.Web;
using Ninject;

namespace OrdersService
{
    public class OrdersService : IOrdersService
    {
        [Inject]
        public IOrderService _orderService;

        public void PlaceOrder(OrderModel order)
        {
        }
    }
}
