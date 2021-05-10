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
    public class TerritoriesController : Controller
    {
        TerritoriesLogic logic = new TerritoriesLogic();
        // GET: Territories
        public ActionResult Index()
        {
            try
            {
                List<Territories> territorios = logic.GetAll();
                List<RegionView> regionViews = territorios.Select(s => new RegionView
                {
                    
                }).ToList();
                return View(regionViews);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}