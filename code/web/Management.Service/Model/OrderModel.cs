using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Management.Service.Model
{
    [DataContract]
    public class CreateOrderModel
    {
        [DataMember(IsRequired = true)]
        public int ProductCode { get; set; }

        [DataMember(IsRequired = true)]
        public int Quantity { get; set; }

        [DataMember(IsRequired = true)]
        public int CustomerId { get; set; }
    }

    [DataContract]
    public class OrderKeyModel
    {
        [DataMember(IsRequired = true)]
        public int ProductCode { get; set; }

        [DataMember(IsRequired = true)]
        public int CustomerId { get; set; }

        [DataMember(IsRequired = true)]
        public DateTime OrderDate { get; set; }
    }

    [DataContract]
    public class OrderModel : OrderKeyModel
    {
        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public int State { get; set; }
    }
}