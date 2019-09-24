using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.MappingClasses;

namespace Classes
{
    public abstract class Order : BaseEntity
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public virtual string Code { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual string Title { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
