using Project.BLL.DesingPatterns.GenericRepository.InRepo;
using Project.BLL.DesingPatterns.SingletonPattern;
using Project.DAL.Context;
using Project.ENTITES.Enums;
using Project.ENTITES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesingPatterns.GenericRepository.BaseRepo
{
    public abstract class NortBaseRepository<T> : IRepository<T> where T : BaseEntity , new()
    {
        protected MyContext _db;

        public NortBaseRepository()
        {
            _db = NrtDBTool.DbInstance;
        }

        protected void Save()
        {
            _db.SaveChanges();
        }
        public void Add(T item)
        {
           _db.Set<T>().Add(item);
            Save();
        }

        public void AddRange(List<T> list)
        {
           _db.Set<T>().AddRange(list);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.DeletedDate = DateTime.Now;
            item.Status = DataStatus.Deleted;

            Save();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (T item in list)
            {
                Delete(item);
            }
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            Save();
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public T FirsOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return Where(x=> x.Status != DataStatus.Deleted);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetDatas(int number)
        {
            return _db.Set<T>().Take(number).ToList();
        }

        public List<T> GetDeleted()
        {
            return Where(x=> x.Status == DataStatus.Deleted);
        }

        public List<T> GetFirstDatas(int number)
        {
            return _db.Set<T>().OrderBy(x => x.CreatedDate).Take(number).ToList();
        }

        public List<T> GetLastDatas(int number)
        {
            return _db.Set<T>().OrderByDescending(x => x.CreatedDate).Take(number).ToList();
        }

        public List<T> GetUpdates()
        {
            return Where(x=> x.Status == DataStatus.Updated);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp).ToList();
        }

        public void SetActives(T item)
        {
            item.ModifiedDate = item.DeletedDate = null;

            item.Status = DataStatus.Inserted;
            Save();
        }

        public void SetActivesRange(List<T> list)
        {
            foreach (T item in list)
            {
                SetActives(item);
            }
        }

        public void Update(T item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Status = DataStatus.Updated;

            T guncellenecek = Find(item.ID);

            _db.Entry(guncellenecek).CurrentValues.SetValues(item);
            Save();
        }

        public void UpdateRange(List<T> list)
        {
            foreach (T item in list)
            {
                Update(item);
            }
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
           return _db.Set<T>().Where(exp).ToList();
        }
    }
}
