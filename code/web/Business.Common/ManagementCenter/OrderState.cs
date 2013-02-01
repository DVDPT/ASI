using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Common.ManagementCenter
{
    public enum OrderState
    {
        Processing = 1,
        BeingHandled = 2,
        Completed = 3,
        Impossible = 4
    }
}
