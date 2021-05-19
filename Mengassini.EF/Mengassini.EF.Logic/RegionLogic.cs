using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mengassini.EF.Data;
using Mengassini.EF.Entities;

namespace Mengassini.EF.Logic
{
    public class RegionLogic : BaseLogic,IABMLogic<Region>
    {
        public List<Region> GetAll()
        {
            return context.Region.ToList();
        }

        public Region GetOne(int id)
        {
            Region region;
            region = context.Region.Find(id);
            return region;
        }

        public void Add(Region newRegion)
        {
            context.Region.Add(newRegion);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var regionAEliminar = context.Region.Find(id);
            context.Region.Remove(regionAEliminar);
            context.SaveChanges();
        }

        public void Update(Region region)
        {
            var regionUpdate = context.Region.Find(region.RegionID);
            regionUpdate.RegionDescription = region.RegionDescription;
            context.SaveChanges();
        }
    }
}
