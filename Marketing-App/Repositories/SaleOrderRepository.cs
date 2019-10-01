using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Interfaces;
using Classes.MappingClasses;
using NHibernate;
using NHibernate.Linq;

namespace Marketing_App.Repositories
{
    public class SaleOrderRepository : ISaleOrderRepository
    {
        private ISession session;
        public IQueryable<SaleOrder> GetAll()
        {
            return session.Query<SaleOrder>();
        }

        public SaleOrder Get(Guid id)
        {
            return session.Get<SaleOrder>(id);
        }

        public void Insert(SaleOrder obj)
        {
            session.Save(obj);
        }

        public void Update(SaleOrder obj)
        {
            session.Update(obj);
        }

        public void Delete(SaleOrder obj)
        {
            session.Delete(obj);
        }
    }
}
