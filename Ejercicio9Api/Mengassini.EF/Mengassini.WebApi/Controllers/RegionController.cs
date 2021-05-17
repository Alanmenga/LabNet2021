using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mengassini.EF.Entities;
using Mengassini.EF.Logic;

namespace Mengassini.WebApi.Controllers
{
    public class RegionController : ApiController
    {
        RegionLogic regionsLogic = new RegionLogic();
        //GET: api/Regions
        public List<RegionsView> Get()
        {
            List<Region> regiones = regionsLogic.GetAll();
            List<RegionsView> regionViews = regiones.Select(s => new RegionsView
            {
                Id = s.RegionID,
                Description = s.RegionDescription
            }).ToList();
            return regionViews;
        }
    }
}
