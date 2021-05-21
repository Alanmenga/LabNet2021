
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mengassini.EF.Entities;
using Mengassini.EF.Logic;

namespace Mengassini.EF.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool condicion = true;
            while (condicion)
            {
                condicion = MenuOpciones();
            }
        }

        private static bool MenuOpciones()
        {
            Console.Clear();
            Console.WriteLine("------------Menu ABM-----------:");
            Console.WriteLine("1-Mostrar Regiones");
            Console.WriteLine("2-Mostrar Productos");
            Console.WriteLine("3-Mostrar Territorios");
            Console.WriteLine("4-Agregar Producto");
            Console.WriteLine("5-Modificar Producto");
            Console.WriteLine("6-Eliminar Producto");
            Console.WriteLine("7-Exit\n");

            switch (Console.ReadLine())
            {
                case "1":
                    MostrarRegion();
                    return true;
                case "2":
                    MostrarProducto();
                    return true;
                case "3":
                    MostrarTerritorio();
                    return true;
                case "4":
                    AgregarProducto();
                    return true;
                case "5":
                    ModificarProducto();
                    return true;
                case "6":
                    EliminarProducto();
                    return true;
                case "7":
                    return false;
                default:
                    return true;
            }
        }
        public static void MostrarRegion()
        {
            RegionLogic regionLogic = new RegionLogic();
            foreach (var item in regionLogic.GetAll())
            {
                Console.WriteLine($"{item.RegionID} - {item.RegionDescription}");
            }
            Console.ReadLine();
        }

        public static void MostrarProducto()
        {
            ProductsLogic productoLogic = new ProductsLogic();
            foreach (var item in productoLogic.GetAll())
            {
                Console.WriteLine($"{item.ProductID} - {item.ProductName}");
            }
            Console.ReadLine();
        }

        public static void MostrarTerritorio()
        {
            TerritoriesLogic territoriesLogic = new TerritoriesLogic();
            foreach (var item in territoriesLogic.GetAll())
            {
                Console.WriteLine($"{item.TerritoryID} - {item.TerritoryDescription}");
            }
            Console.ReadLine();
        }

        public static void AgregarProducto()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            Console.WriteLine("Precio :");
            string precio = (Console.ReadLine());
            Console.WriteLine("Nombre");
            string nombre = (Console.ReadLine());

            productsLogic.Add(new Products
            {
                ProductName = nombre,
                UnitPrice = Int32.Parse(precio)
            });
        }
        public static void ModificarProducto()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            Console.WriteLine("Precio ");
            string precio = (Console.ReadLine());
            Console.WriteLine("Nombre");
            string nombre = (Console.ReadLine());
            Console.WriteLine("Id del producto a modificar :");
            string id = (Console.ReadLine());

            productsLogic.Update(new Products
            {
                ProductName = nombre,
                UnitPrice = Int32.Parse(precio),
                ProductID = Int32.Parse(id)

            });
        }
        public static void EliminarProducto()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            Console.WriteLine("Id del producto a eliminar :");
            string id = (Console.ReadLine());
            productsLogic.Delete(Int32.Parse(id));
        }
    }
}
