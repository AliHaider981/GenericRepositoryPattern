using GenericRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GenericRepositoryPattern.DAL
{
    public class AllRepository<T> : _IAllRepository<T> where T : class
    {
        private DataContext _context;
        private DbSet<T> dbEntity;

        public AllRepository()
        {
            _context = new DataContext();
            dbEntity = _context.Set<T>();
        }

        public void DeleteModel(int id)
        {
            T Model = dbEntity.Find(id);
            dbEntity.Remove(Model);
        }

        public IEnumerable<T> GetModel()
        {
            return dbEntity.ToList();
        }

        public T GetModelById(int id)
        {
            return dbEntity.Find(id);
        }

        public void InsertModel(T model)
        {
            dbEntity.Add(model);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateModel(T model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }

        public IEnumerable<Class> GetAllClass()
        {
            return _context.Classes.ToList();
        }

    }
}