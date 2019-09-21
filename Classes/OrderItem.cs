using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.MappingClasses;

namespace Classes
{
    public abstract class OrderItem
    {
        public OrderItem()
        {
            Id = Guid.NewGuid();
        }
        public virtual Guid Id { get; set; }
        public virtual string NetPrice { get; set; }
        public virtual string Quantity { get; set; }
        public virtual string TotalPrice { get; set; }
        public virtual string UnitPrice { get; set; }
        public virtual Rack Rack { get; set; }
        public virtual Item Item { get; set; }
    }
}
