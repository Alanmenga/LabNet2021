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
    public class ProductController : Controller
    {
        ProductsLogic logic = new ProductsLogic();
        // GET: Product
        public ActionResult Index()
        {
            List<Products> products = logic.GetAll();
            List<ProductsView> productsViews = products.Select(p => new ProductsView
            {
                Id = p.ProductID,
                Name = p.ProductName,
                QuantityPerUnit = p.QuantityPerUnit,
                Price = (decimal)p.UnitPrice
            }).ToList();
            return View(productsViews);
        }

        public ActionResult Update(int id)
        {
            List<Products> products = logic.GetAll();

            List<ProductsView> productsView = products.Where(p => p.ProductID == id).Select(p => new ProductsView
            {
                Id = p.ProductID,
                Name = p.ProductName,
                QuantityPerUnit = p.QuantityPerUnit,
                Price = (decimal)p.UnitPrice
            }).ToList();
            ProductsView productView = productsView[0];
            return View("Insert", productView);
        }

        public ActionResult Insert()
        {
            return View("Insert", new ProductsView());
        }


        [HttpPost]
        public ActionResult InsertUpdate(ProductsView productsView)
        {
            if (productsView.Id <= 0)
            {
                try
                {
                    Products productsEntity = new Products
                    {
                        ProductName = productsView.Name,
                        QuantityPerUnit = productsView.QuantityPerUnit,
                        UnitPrice = productsView.Price
                    };
                    logic.Add(productsEntity);
                    return RedirectToAction("Index");
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
                    Products productsEntity = new Products
                    {
                        ProductName = productsView.Name,
                        QuantityPerUnit = productsView.QuantityPerUnit,
                        UnitPrice = productsView.Price
                    };
                    logic.Update(productsEntity);
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