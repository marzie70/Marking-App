using System;

namespace Classes.MappingClasses
{
    public class Item : BaseEntity
    {
        //public virtual Guid Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
