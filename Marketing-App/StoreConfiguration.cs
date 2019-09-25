using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Classes.MappingClasses;
using FluentNHibernate.Automapping;
using Order = NHibernate.Criterion.Order;

namespace Marketing_App
{
    public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            //return type.Namespace == "Classes.MappingClasses";

            //return type.BaseType == typeof(BaseEntity); just return Parent
            return typeof(BaseEntity).IsAssignableFrom(type) && !type.IsAbstract; /* return all child of root class */
        }
    }
}
