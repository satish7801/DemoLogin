using DemoLogin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoLogin.Service.ServiceInterface
{
    public interface IService<T> where T : class
    {
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);

        public T GetEntity(long Id);

        public void AddEntity(T entity);

        public void DeleteEntity(T entity);

        public void EditEntity(T entity);

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        public int GetCount(Expression<Func<T, bool>> predicate);


        public string GenerateToken(UserDTO user, string Key, string Audience, string Issuer);
    }
}
