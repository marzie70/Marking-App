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
    public class ItemMapping : IAutoMappingOverride<Item>
    {
        public void Override(AutoMapping<Item> mapping)
        {
            mapping.Id(m => m.Id)/*.Not.GeneratedBy.Assigned()*/;
            mapping.Map(m => m.Code);
            mapping.Map(m => m.Name);
            mapping.Map(m => m.Unit);
        }
    }
}
