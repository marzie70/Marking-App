﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.MappingClasses;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Marketing_App.Mapping
{
    class SaleOrderItemMapping : IAutoMappingOverride<SaleOrderItem>
    {
        public void Override(AutoMapping<SaleOrderItem> mapping)
        {
            mapping.Id(m => m.Id).GeneratedBy.Assigned();
            mapping.Map(m => m.NetPrice);
            mapping.Map(m => m.Quantity);
            mapping.Map(m => m.TotalPrice);
            mapping.Map(m => m.UnitPrice);
            //mapping.HasOne(m => m.Rack).Cascade.All();
            //mapping.HasOne(m => m.Item).Cascade.All();
            mapping.References(m => m.Rack);
            mapping.References(m => m.Item);
        }
    }
}
