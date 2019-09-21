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
    class RackItemLevelMapping : IAutoMappingOverride<RackItemLevel>
    {
        public void Override(AutoMapping<RackItemLevel> mapping)
        {
            mapping.Id(m => m.Id).GeneratedBy.Assigned();
            mapping.Map(m => m.CurrentQuantity);
            mapping.Map(m => m.InQuantity);
            mapping.Map(m => m.OutQuantity);
            mapping.References(m => m.Rack);
            mapping.References(m => m.Item);
        }
    }
}
