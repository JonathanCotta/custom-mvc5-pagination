using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Models.Repositorios
{
    public abstract class Repositorio<T> : IRepositorio<T>, IDisposable
    {
        protected ISessionFactory factory = DbConf.CreateSessionFactory();
        protected bool disposed = false;
        protected double itemsPerPage = 5.0;

        public virtual void Add(T obj)
        {
            using (var session = factory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(obj);
                    transaction.Commit();
                }
            }
        }

        public virtual void Delete(int id)
        {
            using (var session = factory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var obj = session.Get<T>(id);
                    session.Delete(obj);
                    transaction.Commit();
                }
            }
        }

        public virtual T Get(int id)
        {
            using (var session = factory.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public virtual IList<T> GetAll()
        {
            using (var session = factory.OpenSession())
            {
                return session.Query<T>().ToList();
            }
        }

        public virtual void Update(T obj)
        {
            using (var session = factory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(obj);
                    transaction.Commit();
                }
            }
        }

        public virtual int getPageCount(int indexCount)
        {
            double pages = indexCount / itemsPerPage;
            int count = (int)pages;
            return (pages - count > 0) ? count + 1 : count;
        }

        public virtual IList<T> GetPageItems(int page)
        {
            var itemsNum = (int)itemsPerPage;
            var skip = (page - 1) * itemsNum;

            using (var session = factory.OpenSession())
            {
                return session.Query<T>().Skip(skip).Take(itemsNum).ToList();
            }
        }

        public virtual IList<T> GetPageItems(int page , IList<T> l)
        {
            var itemsNum = (int)itemsPerPage;
            var skip = (page - 1) * itemsNum;

            return l.Skip(skip).Take(itemsNum).ToList();            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    factory.Dispose();

            disposed = true;
        }
    }
}