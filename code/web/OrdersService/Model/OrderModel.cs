using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OrdersService.Model
{
    [DataContract]
    public class OrderModel
    {
        [DataMember]
        public int ProductCode { get; set; }

        [DataMember]
        public int Quantity { get; set; }
    }
}