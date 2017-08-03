﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.DataContracts.Service
{
    [DataContract]
    public class OrderDataContract
    {
        [DataMember(IsRequired =true)]
        public int Id { get; set; }

        [DataMember(IsRequired = true)]
        public string User { get; set; }

        [DataMember(IsRequired = true)]
        public DateTime OrderDate { get; set; }

        [DataMember(IsRequired = true)]
        public decimal OrderPrice { get; set; }

    }
   
}
