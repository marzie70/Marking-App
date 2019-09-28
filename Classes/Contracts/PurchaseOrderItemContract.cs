using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Contracts
{
    public class PurchaseOrderItemContract
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public Guid RackId { get; set; }
        public string NetPrice { get; set; }
        public string Quantity { get; set; }
        public string TotalPrice { get; set; }
        public string UnitPrice { get; set; }
    }
}
