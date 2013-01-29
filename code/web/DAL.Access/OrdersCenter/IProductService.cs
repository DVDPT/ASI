using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model.OrdersCenter;

namespace DAL.Access.OrdersCenter
{
    public interface IProductService : IDataAccess<OrderCenterProduct, int>
    {
    }
}
