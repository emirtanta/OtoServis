using Microsoft.EntityFrameworkCore;
using OtoServis.Data.Abstract;
using OtoServis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Data.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        internal DatabaseContext _context;
        internal DbSet<T> _dbSet;

        public Repository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// senkron bir şekilde veritabanına bir veri ekler
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// asenkron bir şekilde veritabanına bir veri ekler
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        /// <summary>
        /// senkron bir şekilde id değerine göre bir veri siler
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// senkron bir şekilde bir veriyi id değerine göre bulup getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find(int id)
        {
            return _dbSet.Find(id);
        }


        /// <summary>
        /// asenkron bir şekilde bir veriyi id değerine göre bulup getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }


        /// <summary>
        /// girilen koşula göre veritabındaki ilk veriyi bulup getirir
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        /// <summary>
        /// senkron bir şekilde tün verileri liste şeklinde getirir
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }


        /// <summary>
        /// senkron bir şekilde koşula göre verileri liste şeklinde getirir
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        /// <summary>
        /// tüm listeyi koşulsuz getirir
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// tüm listesiyi belli bir koşula göre filtreleyerek getirir
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        /// <summary>
        /// gireceğiniz koşula göre tek bir değer getirir
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public  Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return  _dbSet.FirstOrDefaultAsync(expression);
        }

        /// <summary>
        /// kaydetme işlemi yapar
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// asenkron kaydetme işlemi yapar
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// veriyi günceller
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
