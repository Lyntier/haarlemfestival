

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using hf.Models;

namespace hf.Repository {

    public abstract class GenericRepository<Type> where Type : class
    {
        protected hfContext _context = new hfContext();

        public ICollection<Type> GetAll(){
            return _context.Set<Type>().ToList();
        }    

        /* Not all classes use id's. Not too useful to force this. */ 
        // public abstract Type Get(int id);

        public void Add(Type entity){
            _context.Set<Type>().Add(entity);
        }

        public void Remove(Type entity){
            _context.Set<Type>().Remove(entity);
        }

        public void Update(Type entity){
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}