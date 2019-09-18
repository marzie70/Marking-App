using System;
using System.Collections.Generic;

namespace Classes.MappingClasses
{
    public class SaleOrder : Order
    {
        public SaleOrder()
        {
            saleOrderItems = new List<SaleOrderItem>();
        }
        public virtual ICollection<SaleOrderItem> saleOrderItems { get; set; }
    }
}
