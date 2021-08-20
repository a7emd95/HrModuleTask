using Core.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Base
{
    public class BaseRepositroy<T> : IRepositroy<T> where T : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public BaseRepositroy(DbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException("Application DbContext is Null");
            _dbSet = _dbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual IQueryable<T> GetWhere(Expression<Func<T, bool>> filter = null, string includedProprites = ""){
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query.Where(filter);
            }

            query = includedProprites.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
              .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query;
        }

        public virtual T GetById(int id){
            return _dbSet.Find(id);
        }

        public T GetFristOrDefult(Expression<Func<T, bool>> filter = null){
            if (filter != null)
                return _dbSet.FirstOrDefault(filter);
            return null;
        }

        public IQueryable<T> GetAllSorted<Tkey>(Expression<Func<T, Tkey>> sortingExpression = null){
            return _dbSet.OrderBy<T, Tkey>(sortingExpression);
        }


        public T Insert(T entity){
            EntityEntry dbEntityEntry = _dbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                _dbSet.Add(entity);
            }
            return entity;
        }

        public virtual void InsertList(List<T> entityList){
            _dbSet.AddRange(entityList);
        }


        public void Update(T enyity){
            EntityEntry dbEntityEntry = _dbContext.Entry(enyity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _dbSet.Attach(enyity);
            }

            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void UpdateList(List<T> entityList){
            foreach (T item in entityList)
            {
                Update(item);
            }
        }


        public void Delete(T entity){
            EntityEntry dbEntityEntry = _dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }

        public void Delete(int entityId){
            T entity = _dbSet.Find(entityId);
            if (entity == null)
                return;
            Delete(entity);
        }


        public IQueryable<T> GetByPage(int pageNumber, int pageSize){
            pageNumber = (pageNumber < 0) ? 1 : pageNumber;
            pageSize = (pageSize > 12 || pageSize < 0) ? 12 : pageSize;
            return _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public bool GetAny(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbSet;
            bool result = false;
            if (filter != null)
            {
                result = query.Any(filter);
            }
            return result;
        }
    }
}
