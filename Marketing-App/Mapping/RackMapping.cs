using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Classes.MappingClasses;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Marketing_App.Mapping
{
    class RackMapping : IAutoMappingOverride<Rack>
    {
        public void Override(AutoMapping<Rack> mapping)
        {
            mapping.Id(m => m.Id)/*.Not.GeneratedBy.Assigned()*/;
            mapping.Map(m => m.Code);
            mapping.Map(m => m.Limit);
            mapping.Map(m => m.Location);
            mapping.Map(m => m.Name);
            mapping.HasMany(m => m.Racks).Cascade.AllDeleteOrphan();
            //mapping.References(m => m.RacksRack);
        }
    }
}
