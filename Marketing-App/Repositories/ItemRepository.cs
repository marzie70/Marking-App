﻿using System;
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
    public class ItemRepository : IItemRepository
    {
        private ISession session;
        public IQueryable<Item> GetAll()
        {
            return session.Query<Item>();
        }

        public Item Get(Guid id)
        {
            return session.Get<Item>(id);
        }

        public void Insert(Item obj)
        {
            session.Save(obj);
        }

        public void Update(Item obj)
        {
            session.Update(obj);
        }

        public void Delete(Item obj)
        {
            //session.Delete(session.Load<Item>(obj));
            session.Delete(obj);
        }
    }
}
//public void Delete(Classes.MappingClasses.Item obj)