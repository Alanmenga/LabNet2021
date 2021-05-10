using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mengassini.EF.Logic;
using Mengassini.EF.Entities;
using Mengassini.MVC.Models;

namespace Mengassini.MVC.Controllers
{
    public class RegionController : Controller
    {
        RegionLogic logic = new RegionLogic();
        // GET: Region
        public ActionResult Index()
        {
            try
            {
                List<Region> regiones = logic.GetAll();
                List<RegionView> regionViews = regiones.Select(s => new RegionView
                {
                    Id = s.RegionID,
                    Description = s.RegionDescription
                }).ToList();
                return View(regionViews);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Update(int id)
        {
            List<Region> region = logic.GetAll();
            List<RegionView> regionsView = region.Where(r => r.RegionID == id).Select(r => new RegionView
            {
                Id = r.RegionID,
                Description = r.RegionDescription
            }).ToList();
            RegionView regionView = regionsView[0];
            return View("Insert", regionsView);
        }

        public ActionResult Insert()
        {
            return View("Insert", new RegionView());
        }


        [HttpPost]
        public ActionResult InsertUpdate(RegionView regionsView)
        {
            if(regionsView.Id <= 0)
            {
                try
                {
                    Region regionEntity = new Region
                    {
                        RegionDescription = regionsView.Description
                    };
                    logic.Add(regionEntity);
                    return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error");
                }
            }
            else
            {
                try
                {
                    Region regionEntity = new Region
                    {
                        RegionDescription = regionsView.Description
                    };
                    logic.Update(regionEntity);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Error");
                }
            }                                                                                 
        }


        public ActionResult Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}