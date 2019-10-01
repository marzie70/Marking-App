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
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private ISession session;
        public IQueryable<PurchaseOrder> GetAll()
        {
            return session.Query<PurchaseOrder>();
        }

        public PurchaseOrder Get(Guid id)
        {
            return session.Get<PurchaseOrder>(id);
        }

        public void Insert(PurchaseOrder obj)
        {
            session.Save(obj);
        }

        public void Update(PurchaseOrder obj)
        {
            session.Update(obj);
        }

        public void Delete(PurchaseOrder obj)
        {
            session.Delete(obj);
        }
    }
}
