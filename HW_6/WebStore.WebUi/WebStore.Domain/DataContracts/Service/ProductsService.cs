using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.DataContracts.Service
{
    [DataContract]
   public class ProductsService
    {
        [DataMember(IsRequired =true)]
        public int Id { get; set; }

        [DataMember(IsRequired =true)]
        public string Name { get; set; }

        [DataMember()]
        public string Descriptions { get; set; }

        [DataMember(IsRequired = true)]
        public decimal Price { get; set; }

        [DataMember(IsRequired = true)]
        public bool IsDeleted { get; set; }

        [DataMember(IsRequired = true)]
        public int Count { get; set; }

        [DataMember(IsRequired = true)]
        public string Category { get; set; }
    }
}
