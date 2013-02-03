using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Management.Service.Model
{
    [DataContract]
    public class ProductModel
    {
        [DataMember]
        public int Code { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int? Quantity { get; set; }

        [DataMember]
        public int? Supplier { get; set; }
    }
}