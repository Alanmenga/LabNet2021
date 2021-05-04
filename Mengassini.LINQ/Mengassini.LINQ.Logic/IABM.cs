using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mengassini.LINQ.Logic
{
    interface IABM<T>
    {
        List<T> GetAll();

        T GetOne(int id);

        void Insert(T elemento);

        void Update(T elemento);

        void Delete(int id);
    }
}
