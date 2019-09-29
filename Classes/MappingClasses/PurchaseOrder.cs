using System.Collections.Generic;

namespace Classes.MappingClasses
{
    public class PurchaseOrder : Order
    {
        public PurchaseOrder()
        {
            purchaseOrderItems = new List<PurchaseOrderItem>();
        }

        public virtual ICollection<PurchaseOrderItem> purchaseOrderItems { get; set; }

        public static bool PurchaseOrderItem { get; set; }
    }
}

