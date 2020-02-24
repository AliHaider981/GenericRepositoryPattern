using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.DAL
{
    interface _IAllRepository<T> where T : class
    {
        IEnumerable<T> GetModel();
        T GetModelById(int id);
        void InsertModel(T model);
        void DeleteModel(int id);
        void UpdateModel(T model);
        void Save();
    }
}
