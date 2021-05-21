using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mengassini.EF.Data;
using Mengassini.EF.Entities;

namespace Mengassini.EF.Logic
{
    public class BaseLogic
    {
        protected readonly NorthwindContext context;

        public BaseLogic()
        {
            context = new NorthwindContext();
        }
    }
}
