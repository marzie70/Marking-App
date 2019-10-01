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
    public class RackRepository : IRackRepository
    {
        private ISession session;
        public IQueryable<Rack> GetAll()
        {
            return session.Query<Rack>();
        }

        public Rack Get(Guid id)
        {
            return session.Get<Rack>(id);
        }


        public void Insert(Rack obj)
        {
            session.Save(obj);
        }

        public void Update(Rack obj)
        {
            session.Update(obj);
        }

        public void Delete(Rack obj)
        {
            session.Delete(obj);
        }
    }
}
