using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Management.Service.Model
{
    [DataContract]
    public class OrderProductModel
    {
        [DataMember]
        public int ProductCode { get; set; }

        [DataMember]
        public int Supplier { get; set; }

        [DataMember]
        public int Quantity { get; set; }
    }

    [DataContract]
    public class SupplierModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }
    }
}