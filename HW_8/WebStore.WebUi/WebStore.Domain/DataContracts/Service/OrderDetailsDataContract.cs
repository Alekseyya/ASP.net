using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.DataContracts.Service
{
    [DataContract]
    public class OrderDetailsDataContract
    {
        //id товара
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        [DataMember(IsRequired = true)]
        public int OrderId { get; set; }

        [DataMember(IsRequired = true)]
        public string Product { get; set; }

        [DataMember(IsRequired = true)]
        public int Quantity { get; set; }

        [DataMember(IsRequired = true)]
        public decimal TotalPrice { get; set; }
    }
}
