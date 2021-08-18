using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Base
{
    public interface IRepositroy<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        T GetById(int entityId);
        T GetFristOrDefult(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetByPage(int pageNumber, int pageSize);
        
        T Insert(T entity);
        void InsertList(List<T> entitiy);

        void Update(T entity);
        void UpdateList(List<T> entitiy);

        void Delete(T entity);
        void Delete(int entityId);
    }
}
