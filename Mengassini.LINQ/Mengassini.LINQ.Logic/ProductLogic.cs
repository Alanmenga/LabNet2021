using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mengassini.LINQ.Entities;
using Mengassini.LINQ.Data;

namespace Mengassini.LINQ.Logic
{
    public class ProductLogic : LogicBase, IABM<Products>
    {
        public string ProductoSinStock()
        {
            var query = from product in context.Products
                        where product.UnitsInStock == 0 || product.UnitsInStock == null
                        select product;

            string datosProducts = "";
            foreach (var product in query)
            {
                datosProducts += $" {product.ProductID}, {product.ProductName}\n";
            }
            return datosProducts;
        }

        public string ProductoStockValenMasDeTres()
        {
            var query = context.Products.Where(p => p.UnitPrice >= 3 && p.UnitsInStock != 0 && p.UnitsInStock != null);
            /*var query3 = from product in context.Products
                           where product.UnitsInStock !=0 && product.UnitPrice >=3 && product.UnitsInStock != null
                           select product;*/


            string datosProducts = "";
            foreach (var product in query)
            {
                datosProducts += $" {product.ProductID}, {product.ProductName}\n";
            }
            return datosProducts;
        }

        public string ProductoId789()
        {
            var query = context.Products.Where(p => p.ProductID == 789);
            var producto = query.FirstOrDefault();

            string datosProduct = "";

            if (producto == null)
                datosProduct += $"No hay producto con id 789\n";
            else
            {
                datosProduct += $" {producto.ProductID}, {producto.ProductName}\n";
            }
            return datosProduct;
        }

        public string ProductosOrdenadosNombre()
        {
            var query = from product in context.Products
                        orderby product.ProductName
                        select product;

            string datosProducts = "";
            foreach (var product in query)
            {
                datosProducts += $" {product.ProductID}, {product.ProductName}\n";
            }
            return datosProducts;
        }

        public string ProductosOrdenadosStock()
        {
            var query = context.Products.OrderByDescending(p => p.UnitsInStock);

            string datosProducts = "";
            foreach (var product in query)
            {
                datosProducts += $" {product.ProductID}, {product.ProductName}, {product.UnitsInStock}\n";
            }
            return datosProducts;
        }

        public string PrimerProducto()
        {
            var query = context.Products.Take(1);
            var producto = query.FirstOrDefault();

            return $"{producto.ProductID}, {producto.ProductName}\n";
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

        public Products GetOne(int id)
        {
            return context.Products.Find(id);
        }

        public void Insert(Products elemento)
        {
            context.Products.Add(elemento);
            context.SaveChanges();
        }

        public void Update(Products elemento)
        {
            var productoUpdate = context.Products.Find(elemento.ProductID);
            productoUpdate.ProductName = elemento.ProductName;
            context.SaveChanges();
        }
    }
}
