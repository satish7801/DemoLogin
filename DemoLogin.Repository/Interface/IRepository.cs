using DemoLogin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoLogin.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        T Get(long id);
        void AddEntity(T entity);
        void DeleteEntity(T entity);
        void EditEntity(T entity);
        void Save();
        public void Dispose();

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        public int GetCount(Expression<Func<T, bool>> predicate);

    }
}
