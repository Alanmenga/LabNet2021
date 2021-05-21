using Mengassini.EF.Entities;
using Mengassini.EF.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;


namespace Mengassini.WebApi.Controllers
{
    public class RegionController : ApiController
    {
        private RegionLogic regionLogic = new RegionLogic();
        // GET: api/Region
        public List<RegionsView> GetRegions()
        {
            var regions = regionLogic.GetAll();
            var regionsView = regions.Select(r => new RegionsView
            {
                Id = r.RegionID,
                Description = r.RegionDescription
            }).ToList();
            return regionsView;
        }

        // GET: api/Region/5
        [ResponseType(typeof(Region))]
        public IHttpActionResult GetRegion(int id)
        {
            Region region = regionLogic.GetOne(id);
            if (region == null)
            {
                return NotFound();
            }
            RegionsView regionsView = new RegionsView
            {
                Id = region.RegionID,
                Description = region.RegionDescription
            };
            return Ok(regionsView);
        }

        // PUT: api/Region/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegion(int id, RegionsView regionsView)
        {
            Region region = regionLogic.GetOne(id);
            region.RegionDescription = regionsView.Description;
            try
            {
                regionLogic.Update(region);
                return Ok(regionsView);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Region
        [ResponseType(typeof(Region))]
        public IHttpActionResult PostRegion(RegionsView regionView)
        {
            try
            {
                Region region = new Region
                {
                    RegionID = regionView.Id,
                    RegionDescription = regionView.Description
                };
                regionLogic.Add(region);
                return Ok(regionView);
            }
            catch (Exception)
            {
                return InternalServerError();
            }


        }

        // DELETE: api/Region/5
        [ResponseType(typeof(Region))]
        public IHttpActionResult DeleteRegion(int id)
        {
            Region region = regionLogic.GetOne(id);
            if (region == null)
            {
                return NotFound();
            }
            try
            {
                regionLogic.Delete(id);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            RegionsView regionsView = new RegionsView
            {
                Id = region.RegionID,
                Description = region.RegionDescription
            };

            return Ok(regionsView);
        }
    }
}