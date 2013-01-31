using System.Runtime.Serialization;

namespace Orders.Service.Model
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