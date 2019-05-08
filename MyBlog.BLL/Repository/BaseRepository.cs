using MyBlog.DAL.ORM.Context;
using MyBlog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace MyBlog.BLL.Repository
{
    public class BaseRepository<T> where T: BaseEntity
    {
        private ProjeContext db;
        protected DbSet<T> table;

        public BaseRepository()
        {
            db = new ProjeContext();
            table = db.Set<T>();
        }
        // GetAll Add Any  GetDefault GetByID Remove  RemoveAll Save Update

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public void Add(T item)
        {
            item.Status = DAL.ORM.Enum.Status.Active;
            table.Add(item);
            Save();
        }
        public void Add(List<T> items)
        {
            table.AddRange(items);
            Save();
        }
        public void Update(T item)
        {
            T updated = GetById(item.ID);
            DbEntityEntry entry = db.Entry(updated);
            
            entry.CurrentValues.SetValues(item);
            Save();

        }
        public List<T> GetActive()
        {
            return table.Where(x => x.Status == DAL.ORM.Enum.Status.Active).ToList();
        }
        public List<T> GetDefault(Expression<Func<T,bool>>exp)
        {
            return table.Where(exp).ToList();
        }
        public bool Any(Expression<Func<T, bool>> exp) => table.Any(exp);
        
        public  T GetById(Guid id)
        {
            return table.Find(id);
        }
        public void Remove(Guid id)
        {
            T item = GetById(id);
            item.Status = DAL.ORM.Enum.Status.Deleted;
            Update(item);
            
        }
        public void RemoveAll(Expression<Func<T,bool>>exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = DAL.ORM.Enum.Status.Deleted;
                Update(item);

            }
        }
        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).FirstOrDefault();
        }


    }
}
