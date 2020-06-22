
using TCC.Domain.Entities;
using System.Linq.Expressions;

namespace TCC.Infra.Repositories
{
    using TCC.Application;
    using TCC.Application.Interfaces;
    using TCC.Infra.Context;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class RepositoryBase<T> where T : BaseEntity
    {
        public AcademiaContext Context;
        private IDbSet<T> entities;
        private DbContextTransaction _transaction;

        public readonly ICrudMsgFormater _crudMsgFormater = new CrudMsgFormater();

        public RepositoryBase(AcademiaContext context)
        {
            Context = context;
        }

        public RepositoryBase()
        {
            Context = new AcademiaContext();
        }

        private IDbSet<T> Entity
        {
            get
            {
                if (entities == null)
                {
                    entities = Context.Set<T>();
                }
                return entities;
            }
        }

        public virtual void Add(T obj)
        {
            try
            {
                obj.DataRegistro = DateTime.Now;
                Entity.Add(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> AddRange(IEnumerable<T> obj)
        {
            return ((DbSet<T>)Entity).AddRange(obj);
        }

        public IEnumerable<T> RemoveRange(IEnumerable<T> obj)
        {
            return ((DbSet<T>)Entity).RemoveRange(obj);
        }

        public virtual void Update(T obj)
        {
            try
            {
                Context.Entry(obj).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(int id)
        {
            try
            {
                var obj = GetById(id);
                obj.DataExclusao = DateTime.Now;

                Update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(long id)
        {
            try
            {
                var obj = GetById(id);
                obj.DataExclusao = DateTime.Now;

                Update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(T obj)
        {
            try
            {
                obj.DataExclusao = DateTime.Now;

                Update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T GetById(int id)
        {
            try
            {
                return Entity.FirstOrDefault(x => x.Id == id && x.DataExclusao == null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T GetById(long id)
        {
            try
            {
                return Entity.FirstOrDefault(x => x.Id == id && x.DataExclusao == null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> GetAllList()
        {
            try
            {
                return Entity.Where(x => x.DataExclusao == null).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return Entity.Where(x => x.DataExclusao == null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return Entity.Where(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(T obj)
        {
            try
            {
                Entity.Attach(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
                if (Context != null)
                {
                    Context.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void BeginTransaction()
        {
            _transaction = Context.Database.BeginTransaction();
        }

    }
}
