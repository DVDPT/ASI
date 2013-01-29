using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model.Common;

namespace DAL.Access.Common
{
    public interface ICustomerService : IDataAccess<CustomerBase, int>
    {
    }
}
