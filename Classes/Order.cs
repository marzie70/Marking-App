using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
            OrderItems = new List<OrderItem>();
        }
        public virtual Guid Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string CreationDate { get; set; }
        public virtual string Title { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
