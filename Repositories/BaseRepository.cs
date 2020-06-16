
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private WarframeEntities Context = new WarframeEntities();


        protected DbSet<T> DBSet
        {
            get
            {
                return Context.Set<T>();
            }
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetByID(int? id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Update(T item, Func<T, bool> findByPredicate)
        {
            var local = Context.Set<T>().Local.FirstOrDefault(findByPredicate);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }
            Context.Entry(item).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public bool DeleteByID(int id)
        {
            bool isDeleted = false;
            T dbItem = Context.Set<T>().Find(id);
            if (dbItem != null)
            {
                Context.Set<T>().Remove(dbItem);
                int recordsChanged = Context.SaveChanges();
                isDeleted = recordsChanged > 0;
            }
            return isDeleted;
        }

        public void Create(T item)
        {
            try
            {
                Context.Set<T>().Add(item);
                Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);


                var fullErrorMessage = string.Join("; ;", errorMessages);


                var exceptionMessage = string.Concat(ex.Message, "The validation errors are:", fullErrorMessage);


                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

    }
}
