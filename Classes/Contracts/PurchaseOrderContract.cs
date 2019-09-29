using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.MappingClasses;

namespace Classes.Contracts
{
    public class PurchaseOrderContract
    {
        public Guid Id { get; set; }
        public List<PurchaseOrderItemContract> PurchaseOrderItemContracts { get; set; }
        public string Code { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
    }
}
