using Mengassini.EF.Entities;
using Mengassini.EF.Logic;
using Mengassini.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Mengassini.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductsLogic productLogic = new ProductsLogic();
        // GET: api/Products
        public List<ProductsView> GetProducts()
        {
                List<Products> products = productLogic.GetAll();
                List<ProductsView> productsView = products.Select(p => new ProductsView
                {
                    Id = p.ProductID,
                    Nombre = p.ProductName,
                    Cantidad = p.QuantityPerUnit,
                    Precio = p.UnitPrice,
                    UStock = p.UnitsInStock,
                    UOrdenadas = p.UnitsOnOrder
                }).ToList();
                return productsView;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Products))]
        public IHttpActionResult GetProducts(int id)
        {
            Products products = productLogic.GetOne(id);
            if(products == null)
            {
                return NotFound();
            }
            ProductsView productsView = new ProductsView
            {
                Id = products.ProductID,
                Nombre = products.ProductName,
                Cantidad = products.QuantityPerUnit,
                Precio = products.UnitPrice,
                UStock = products.UnitsInStock,
                UOrdenadas = products.UnitsOnOrder
            };
            return Ok(productsView);
        }

        // PUT: api/Products/5
        public IHttpActionResult PutProducts(int id,ProductsView productsView)
        {
            Products product = productLogic.GetOne(id);
            product.ProductName = productsView.Nombre;
            product.QuantityPerUnit = productsView.Cantidad;
            product.UnitPrice = productsView.Precio;
            product.UnitsInStock = productsView.UStock;
            product.UnitsOnOrder = productsView.UOrdenadas;

            try
            {
                productLogic.Update(product);
                return Ok(productsView);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Products
        [ResponseType(typeof(Products))]
        public IHttpActionResult PostProducts(ProductsView productsView)
        {
            try
            {
                Products products = new Products
                {
                    ProductID = productsView.Id,
                    ProductName = productsView.Nombre,
                    QuantityPerUnit = productsView.Cantidad,
                    UnitPrice = productsView.Precio,
                    UnitsOnOrder = productsView.UOrdenadas,
                    UnitsInStock = productsView.UStock
                };
                productLogic.Add(products);
                return Ok(productsView);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Products))]
        public IHttpActionResult DeleteProducts(int id)
        {
            Products product = productLogic.GetOne(id);
            if(product == null)
            {
                return NotFound();
            }
            try
            {
                productLogic.Delete(id);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            ProductsView productsView = new ProductsView
            {
                Id = product.ProductID,
                Nombre = product.ProductName,
                Cantidad = product.QuantityPerUnit,
                Precio = product.UnitPrice,
                UOrdenadas = product.UnitsOnOrder,
                UStock = product.UnitsInStock
            };

            return Ok(productsView);
        }
    }
}