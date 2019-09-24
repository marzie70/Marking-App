using System;

namespace Classes.MappingClasses
{
    public class RackItemLevel : BaseEntity
    {
        //public virtual Guid Id { get; set; }
        public virtual string CurrentQuantity { get; set; }
        public virtual string InQuantity { get; set; }
        public virtual string OutQuantity { get; set; }
        public virtual Item Item { get; set; }
        public virtual Rack Rack { get; set; }
    }
}
