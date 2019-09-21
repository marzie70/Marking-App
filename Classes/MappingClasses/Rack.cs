using System;
using System.Collections.Generic;

namespace Classes.MappingClasses
{
    public class Rack
    {
        public Rack()
        {
            Id = Guid.NewGuid();
            Racks = new List<Rack>();
        }
        public virtual Guid Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Limit { get; set; }
        public virtual string Location { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Rack> Racks { get; set; }
        //public virtual Rack RacksRack { get; set; }
    }
}
