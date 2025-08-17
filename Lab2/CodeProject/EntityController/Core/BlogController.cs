using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EntityModel;
// Nếu dùng điều kiện dạng chuỗi:
using System.Linq.Dynamic.Core; // nhớ cài gói System.Linq.Dynamic.Core cho project EntityController

namespace EntityController
{
    public class BlogController : Base
    {
        public DbSet<Blog> Execute;
        public BlogController() { Execute = db.Blogs; }

        public List<Blog> ExecuteQuery(string query)
            => Execute.SqlQuery(query).ToList();

        // INSERT
        public bool Insert(Blog b) {    Execute.Add(b); return db.SaveChanges() > 0; }
        public bool Insert(List<Blog> list) { Execute.AddRange(list); try { db.SaveChanges(); } catch { return false; } return true; }

        // DELETE
        public bool DeleteWhere(string conditions)
        { Execute.RemoveRange(Execute.AsQueryable().Where(conditions).ToList()); try { db.SaveChanges(); } catch { return false; } return true; }

        public bool Delete(Blog b)
        { Execute.Attach(b); Execute.Remove(b); try { db.SaveChanges(); } catch { return false; } return true; }

        public bool Delete(List<Blog> list)
        { foreach (var b in list) { Execute.Attach(b); Execute.Remove(b); } try { db.SaveChanges(); } catch { return false; } return true; }

        // SELECT
        public List<Blog> SelectWhere(string conditions)
            => Execute.AsQueryable().Where(conditions).ToList();

        public List<Blog> SelectOrderWhere(string conditions, string orders)
            => Execute.AsQueryable().Where(conditions).OrderBy(orders).ToList();

        public List<Blog> SelectAll()
            => Execute.ToList();

        public List<Blog> SelectAll(string orders)
            => Execute.AsQueryable().OrderBy(orders).ToList();

        public List<Blog> SelectTop(int number)
            => Execute.Take(number).ToList();

        public List<Blog> SelectTop(int number, string orders)
            => Execute.AsQueryable().OrderBy(orders).Take(number).ToList();

        // UPDATE
        public bool Update(Blog b)
        { Execute.Attach(b); db.Entry(b).State = EntityState.Modified; return db.SaveChanges() > 0; }

        public bool Update(List<Blog> list)
        {
            foreach (var b in list) { Execute.Attach(b); db.Entry(b).State = EntityState.Modified; }
            try { db.SaveChanges(); } catch { return false; }
            return true;
        }
    }
}
