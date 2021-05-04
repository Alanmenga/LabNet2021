using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mengassini.LINQ.Entities;
using Mengassini.LINQ.Data;

namespace Mengassini.LINQ.Logic
{
    public abstract class LogicBase
    {
        protected readonly NorthwindContext context;

        public LogicBase()
        {
            context = new NorthwindContext();
        }
    }
}
