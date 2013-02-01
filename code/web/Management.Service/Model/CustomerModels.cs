using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Management.Service.Model
{
    [DataContract]
    public class CustomerModel : CreateCustomerModel
    {
        [DataMember]
        public int Number { get; set; }
    }

    [DataContract]
    public class CreateCustomerModel
    {
        [DataMember(IsRequired = true)]
        public string Address { get; set; }

        [DataMember(IsRequired = true)]
        public string EmailAddress { get; set; }
    }

    [DataContract]
    public class RemoveCustomerModel
    {
        [DataMember]
        public int CustomerNumber { get; set; }
    }
}