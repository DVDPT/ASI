using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model.ManagementCenter;

namespace DAL.Access.ManagementCenter
{
    public interface IProductMapper : IDataMapper<ManagementCenterProduct,int>
    {
    }
}
