using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.DataContracts.Service
{
    public class OrderDataContract
    {
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime OrderDate { get; set; }

    }
    public class OrderDetailDataContract
    {
        public int Id { get; set; }
        public List<string> Product { get; set; }

        public int Quantity { get; set; }

    }
}
