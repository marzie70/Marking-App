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
    public class PurchaseOrderItemMapping : IAutoMappingOverride<PurchaseOrderItem>
    {
        public void Override(AutoMapping<PurchaseOrderItem> mapping)
        {
            mapping.Id(m => m.Id).GeneratedBy.Assigned();
            mapping.Map(m => m.NetPrice);
            mapping.Map(m => m.Quantity);
            mapping.Map(m => m.TotalPrice);
            mapping.Map(m => m.UnitPrice);
            mapping.References(m => m.Rack);
            mapping.References(m => m.Item);
        }
    }
}
