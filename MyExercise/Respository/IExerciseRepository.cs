using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExercise.Repository
{
    interface IExerciseRepository<T> where T : class
    {
        //IEnumerable<T> GetAllData();
        IQueryable<T> GetAllData();
        T SelectDataById(object id);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        void InsertRecord(T objRecord);
        void Update(T objRecord);
        void DeleteRecord(object id);
        void SaveRecord();
    }
}
