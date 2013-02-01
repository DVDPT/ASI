using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Management.Service.Model
{
    [DataContract]
    public class CustomerOrderModel
    {
        [DataMember]
        public int ProductCode { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public int CustomerId { get; set; }
    }
}