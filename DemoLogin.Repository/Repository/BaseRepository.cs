using DemoLogin.DTO;
using DemoLogin.Models.Data;
using DemoLogin.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DemoLogin.Repository.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly CiPlatformContext _ciPlatformContext;
        protected readonly DbSet<T> _dbset;

        public BaseRepository(CiPlatformContext ciPlatformContext)
        {
            _ciPlatformContext = ciPlatformContext;
            _dbset = ciPlatformContext.Set<T>();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).ToList();
        }

        public T Get(long id)
        {
            return _dbset.Find(id)!;
        }

        public void AddEntity(T entity)
        {
            _dbset.Add(entity);
            Save();
            Dispose();
        }

        public void DeleteEntity(T entity)
        {
            _dbset.Remove(entity);
            Save();
            Dispose();
        }

        public void EditEntity(T entity)
        {
            _dbset.Update(entity);
            Save();
            Dispose();
        }

        public void Save()
        {
            _ciPlatformContext.SaveChanges();
        }

        public void Dispose()
        {
            _ciPlatformContext.Dispose();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).AsEnumerable();
        }

        public int GetCount(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).Count();
        }

    }
}
