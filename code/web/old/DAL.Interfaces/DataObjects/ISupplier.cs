using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISupplier
    {
        int Id { get; set; }

        string Name { get; set; }
    }
}
