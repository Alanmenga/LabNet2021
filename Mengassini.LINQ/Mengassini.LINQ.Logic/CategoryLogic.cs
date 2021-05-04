using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mengassini.LINQ.Entities;
using Mengassini.LINQ.Data;

namespace Mengassini.LINQ.Logic
{
    public class CategoryLogic : LogicBase, IABM<Categories>
    {
        public string CategoriasAsociadas()
        {
            var query = from prod in context.Products
                        join idCat in context.Categories on prod.CategoryID equals idCat.CategoryID
                        group idCat by idCat.CategoryName into newGroup
                        select newGroup.Key;

            string datosCategotias = "";
            foreach (var categoria in query)
            {
                datosCategotias += $" {categoria}\n";
            }
            return datosCategotias;
        }

        public void Delete(int id)
        {
            var categoryAEliminar = context.Categories.Find(id);
            context.Categories.Remove(categoryAEliminar);
            context.SaveChanges();
        }

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public Categories GetOne(int id)
        {
            return context.Categories.Find(id);
        }

        public void Insert(Categories elemento)
        {
            context.Categories.Add(elemento);
            context.SaveChanges();
        }

        public void Update(Categories elemento)
        {
            var categoryUpdate = context.Categories.Find(elemento.CategoryID);
            categoryUpdate.CategoryName = elemento.CategoryName;
            context.SaveChanges();
        }
    }
}
