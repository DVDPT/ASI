using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALFactory
    {
        public static T GetService<T>() where T : IDataAccess
        {

        }
    }
}
