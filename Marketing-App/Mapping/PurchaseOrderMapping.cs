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
    public class PurchaseOrderMapping : IAutoMappingOverride<PurchaseOrder>
    {
        public void Override(AutoMapping<PurchaseOrder> mapping)
        {
            mapping.Id(m => m.Id)/*.GeneratedBy.Assigned()*/;
            mapping.Map(m => m.Code);
            mapping.Map(m => m.CreationDate);
            mapping.Map(m => m.Title);
            mapping.HasMany(m => m.PurchaseOrderItems).Cascade.AllDeleteOrphan();
        }
    }
}
