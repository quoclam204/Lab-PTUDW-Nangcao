using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using EntityModel;
using Entity = EntityModel.Post;

namespace EntityController
{
    public partial class PostController : Base
    {
        public DbSet<Entity> Execute;
        public PostController()
        {
            Execute = db.Posts;
        }

        // --- Common execution ---
        // Execute SQL string cho entity này (ví dụ: "select * from Post")
        public List<Entity> ExecuteQuery(string query)
        {
            return Execute.SqlQuery(query).ToList();
        }

        // --- Insert ---
        public bool Insert(Entity e)
        {
            Execute.Add(e);
            return db.SaveChanges() > 0;
        }

        public bool Insert(List<Entity> list)
        {
            foreach (var e in list) Execute.Add(e);
            try { db.SaveChanges(); } catch { return false; }
            return true;
        }

        // --- Delete queries ---
        // Xóa theo điều kiện (không dùng cho LIKE)
        public bool DeleteWhere(string conditions)
        {
            Execute.RemoveRange(Execute.AsQueryable().Where(conditions).ToList());
            try { db.SaveChanges(); } catch { return false; }
            return true;
        }

        public bool Delete(Entity e)
        {
            Execute.Attach(e);
            Execute.Remove(e);
            try { db.SaveChanges(); } catch { return false; }
            return true;
        }

        public bool Delete(List<Entity> list)
        {
            foreach (var e in list) { Execute.Attach(e); Execute.Remove(e); }
            try { db.SaveChanges(); } catch { return false; }
            return true;
        }

        // --- Select queries ---
        public List<Entity> SelectWhere(string conditions)
        {
            return Execute.AsQueryable().Where(conditions).ToList();
        }

        public List<Entity> SelectOrderWhere(string conditions, string orders)
        {
            return Execute.AsQueryable().Where(conditions).OrderBy(orders).ToList();
        }

        public List<Entity> SelectAll()
        {
            return Execute.ToList();
        }

        public List<Entity> SelectAll(string orders)
        {
            return Execute.AsQueryable().OrderBy(orders).ToList();
        }

        public List<Entity> SelectTop(int number)
        {
            return Execute.Take(number).ToList();
        }

        public List<Entity> SelectTop(int number, string orders)
        {
            return Execute.AsQueryable().OrderBy(orders).Take(number).ToList();
        }

        // --- Update ---
        public bool Update(Entity e)
        {
            Execute.Attach(e);
            db.Entry(e).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool Update(List<Entity> list)
        {
            foreach (var e in list)
            {
                Execute.Attach(e);
                db.Entry(e).State = EntityState.Modified;
            }
            try { db.SaveChanges(); } catch { return false; }
            return true;
        }
    }
}