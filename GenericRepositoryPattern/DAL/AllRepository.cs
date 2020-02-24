using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenericRepositoryPattern.DAL
{
    public class AllRepository<T> : _IAllRepository<T> where T : class
    {
    }
}