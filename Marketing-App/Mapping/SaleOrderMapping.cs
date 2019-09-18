using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.MappingClasses;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Marketing_App.Mapping
{
    class SaleOrderMapping : IAutoMappingOverride<SaleOrder>
    {
        public void Override(AutoMapping<SaleOrder> mapping)
        {
            mapping.Id(m => m.Id).GeneratedBy.Assigned();
            mapping.Map(m => m.Code);
            mapping.Map(m => m.CreationDate);
            mapping.Map(m => m.Title);
            mapping.HasMany(m => m.SaleOrderItems).Cascade.AllDeleteOrphan();
        }
    }
}
