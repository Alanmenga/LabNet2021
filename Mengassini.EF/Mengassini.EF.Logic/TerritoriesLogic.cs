using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mengassini.EF.Data;
using Mengassini.EF.Entities;

namespace Mengassini.EF.Logic
{
    public class TerritoriesLogic : BaseLogic, IABMLogic<Territories>
    {
        public void Add(Territories element)
        {
            context.Territories.Add(element);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var territorioAEliminar = context.Territories.Find(id);
            context.Territories.Remove(territorioAEliminar);
            context.SaveChanges();
        }

        public List<Territories> GetAll()
        {
            return context.Territories.ToList();
        }

        public void Update(Territories territorio)
        {
            var territorioUpdate = context.Territories.Find(territorio.RegionID);
            territorioUpdate.TerritoryDescription = territorio.TerritoryDescription;
            context.SaveChanges();
        }
    }
}
