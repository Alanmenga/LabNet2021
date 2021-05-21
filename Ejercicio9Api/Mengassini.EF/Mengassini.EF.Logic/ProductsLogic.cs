using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mengassini.EF.Data;
using Mengassini.EF.Entities;

namespace Mengassini.EF.Logic
{
    public class ProductsLogic : BaseLogic,IABMLogic<Products>
    {
        public void Add(Products newProduct)
        {
            context.Products.Add(newProduct);
            context.SaveChanges();
        }

        public Products GetOne(int id)
        {
            Products product;
            product = context.Products.Find(id);
            return product;
        }

        public void Delete(int id)
        {
            var productAEliminar = context.Products.Find(id);
            context.Products.Remove(productAEliminar);
            context.SaveChanges();
        }

        public List<Products> GetAll()
        {
            return context.Products.ToList();
        }

        public void Update(Products product)
        {
            var productoUpdate = context.Products.Find(product.ProductID);
            productoUpdate.ProductName = product.ProductName;
            productoUpdate.QuantityPerUnit = product.QuantityPerUnit;
            productoUpdate.UnitPrice = product.UnitPrice;
            productoUpdate.UnitsInStock = product.UnitsInStock;
            productoUpdate.UnitsOnOrder = product.UnitsOnOrder;

            context.SaveChanges();
        }
    }
}
