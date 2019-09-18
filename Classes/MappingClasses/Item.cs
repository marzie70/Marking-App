using System;

namespace Classes.MappingClasses
{
    public class Item
    {
        public Item()
        {
            Id = Guid.NewGuid();
        }
        public virtual Guid Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
