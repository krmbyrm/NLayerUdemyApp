using System;
using NLayer.Core.Reporstories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace NLayer.Repository.Repositories
{
    public class GenericRepository<T> : IGenericReporsitory<T> where T : class
    {
        protected readonly AppDbContext _context;

        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)//appDbContextten alır
        {
            _context = context;
            _dbSet = _context.Set<T>();//efCore bu contexti set eder 
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return  _dbSet.AsNoTracking().AsQueryable();// asnoTrackin => data daha veritabanına giştmeden (order by vb) işlemler için track etmeden performans amaçlı kullanım
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id); // FindAsync bizden bir key bekler ve Task<entity> döndürür.
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);//remove islemi sadece flag set eder silme işlemi yapmadığı için async değil
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
             _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
