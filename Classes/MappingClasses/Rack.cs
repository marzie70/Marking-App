using System;
using System.Collections.Generic;

namespace Classes.MappingClasses
{
    public class Rack : BaseEntity
    {
        //public virtual Guid Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Limit { get; set; }
        public virtual string Location { get; set; }
        public virtual string Name { get; set; }
        //public virtual ICollection<Rack> Racks { get; set; } ghalate chon loop darim
        public virtual Rack RacksRack { get; set; }

        public string Nam { get; set; }
    }
}
