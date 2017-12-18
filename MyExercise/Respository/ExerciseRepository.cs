using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MyExercise.Repository
{
    public class ExerciseRepository<T> : IExerciseRepository<T> where T : class
    {
        private ExerciseDBContext db = null;
        private DbSet<T> dbEntity = null;

        public ExerciseRepository()
        {
            this.db = new ExerciseDBContext();
            dbEntity = db.Set<T>();
        }

        public ExerciseRepository(ExerciseDBContext _db)
        {
            this.db = _db;
            dbEntity = db.Set<T>();
        }

        //public IEnumerable<T> GetAllData()
        public IQueryable<T> GetAllData()
        {
            //return dbEntity.ToList();
            return (DbSet<T>)dbEntity;
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return (DbSet<T>)dbEntity.Where(predicate);
        }

        public T SelectDataById(object id)
        {
            return dbEntity.Find(id);
        }

        public void InsertRecord(T objRecord)
        {
            dbEntity.Add(objRecord);
        }

        public void Update(T objRecord)
        {
            dbEntity.Attach(objRecord);
            db.Entry(objRecord).State = System.Data.Entity.EntityState.Modified;
        }

        public void DeleteRecord(object id)
        {
            T currentRecord = dbEntity.Find(id);
            dbEntity.Remove(currentRecord);
        }

        public void SaveRecord()
        {
            db.SaveChanges();
        }
    }
}