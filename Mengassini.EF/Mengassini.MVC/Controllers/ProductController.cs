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
            List<Products> productos = logic.GetAll();

            List<ProductView> productsView = productos.Select(p => new ProductView
            {
                Id = p.ProductID,
                Nombre = p.ProductName,
                Cantidad = p.QuantityPerUnit,
                Precio = p.UnitPrice,
                UStock = p.UnitsInStock,
                UOrdenadas = p.UnitsOnOrder
            }).ToList();

            return View(productsView);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ProductView productView)
        {
            try
            {
                Products productEntity = new Products
                {
                    ProductName = productView.Nombre,
                    UnitPrice = productView.Precio
                };
                logic.Add(productEntity);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
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