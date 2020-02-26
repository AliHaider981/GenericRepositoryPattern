using GenericRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.DAL
{
    //https://yogeshdotnet.com/generic-repository-pattern-c-entity-framework-6-lecture-16-hindi/
    //https://www.youtube.com/watch?v=vCw_LhhSFU4


    interface _IAllRepository<T> where T : class
    {
        IEnumerable<T> GetModel();
        T GetModelById(int id);
        void InsertModel(T model);
        void DeleteModel(int id);
        void UpdateModel(T model);

        IEnumerable<Class> GetAllClass();
        void Save();
    }
}
