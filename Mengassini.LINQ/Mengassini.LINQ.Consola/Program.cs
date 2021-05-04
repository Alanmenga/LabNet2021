using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mengassini.LINQ.Entities;
using Mengassini.LINQ.Logic;

namespace Mengassini.LINQ.Consola
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
            Console.WriteLine("------------Menu Opciones LINQ-----------:");
            Console.WriteLine("1-Devolver objeto customer");
            Console.WriteLine("2-Devolver todos los productos sin stock");
            Console.WriteLine("3-Devolver todos los productos que tienen stock y que cuestan más de 3 por unidad");
            Console.WriteLine("4-Devolver todos los customers de Washington");
            Console.WriteLine("5-Devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
            Console.WriteLine("6-Devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.");
            Console.WriteLine("7-Devolver Join entre Customers y Orders donde los customers sean de Washington y la fecha de orden sea mayor a 1 / 1 / 1997.");
            Console.WriteLine("8-Devolver los primeros 3 Customers de Washington");
            Console.WriteLine("9-Devolver lista de productos ordenados por nombre");
            Console.WriteLine("10-Devolver lista de productos ordenados por unit in stock de mayor a menor.");
            Console.WriteLine("11-Devolver las distintas categorías asociadas a los productos");
            Console.WriteLine("12-Devolver el primer elemento de una lista de productos");
            Console.WriteLine("13-Eliminar Producto");
            Console.WriteLine("14-Devolver los customer con la cantidad de ordenes asociadas\n");

            switch (Console.ReadLine())
            {
                case "1":
                    Ejercicio1();
                    return true;
                case "2":
                    Ejercicio2();
                    return true;
                case "3":
                    Ejercicio3();
                    return true;
                case "4":
                    Ejercicio4();
                    return true;
                case "5":
                    Ejercicio5();
                    return true;
                case "6":
                    Ejercicio6();
                    return true;
                case "7":
                    Ejercicio7();
                    return true;
                case "8":
                    Ejercicio8();
                    return true;
                case "9":
                    Ejercicio9();
                    return true;
                case "10":
                    Ejercicio10();
                    return true;
                case "11":
                    Ejercicio11();
                    return true;
                case "12":
                    Ejercicio12();
                    return true;
                case "13":
                    Ejercicio13();
                    return true;
                case "14":
                    return false;
                default:
                    return true;
            }
        }

        //1. Query para devolver objeto customer
        public static void Ejercicio1()
        {
            try
            {
                CustomerLogic customerLogic = new CustomerLogic();
                Console.WriteLine(customerLogic.GetDatos());
                Console.WriteLine("Ingrese ID Customer: ");
                Customers customer = customerLogic.GetOne(Console.ReadLine().ToUpper());
                if (customer == null)
                    Console.WriteLine($"No extiste el customer con ese ID;");
                else
                    Console.WriteLine($"ID: {customer.CustomerID}\nNombre: {customer.ContactName}\nDireccion: {customer.Address}");
            }
            catch(Exception e)
            {
                Console.Write("Id ingresado incorrecto");
            }
            Console.ReadKey();
        }

        //2.Query para devolver todos los productos sin stock
        public static void Ejercicio2()
        {
            ProductLogic productoLogic = new ProductLogic();
            Console.WriteLine($"Devolver todos los productos sin stock");
            Console.WriteLine(productoLogic.ProductoSinStock());
            Console.ReadKey();
        }

        //3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad
        public static void Ejercicio3()
        {
            ProductLogic productoLogic = new ProductLogic();
            Console.WriteLine($"Productos que tienen stock y que cuestan más de 3 por unidad:");
            Console.WriteLine(productoLogic.ProductoStockValenMasDeTres());
            Console.ReadKey();
        }

        //4.Query para devolver todos los customers de Washington
        public static void Ejercicio4()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            Console.WriteLine($"Customers de Washington:");
            Console.WriteLine(customerLogic.CustomersWashington());
            Console.ReadKey();
        }

        //5. Query para devolver el primer elemento o nulo de una 
        //   lista de productos donde el ID deproducto sea igual a 789
        public static void Ejercicio5()
        {
            ProductLogic productoLogic = new ProductLogic();
            Console.WriteLine($"Producto Id 789:");
            Console.WriteLine(productoLogic.ProductoId789());
            Console.ReadKey();
        }

        //6. Query para devolver los nombre de los Customers. Mostrarlos 
        //   en Mayuscula y en Minuscula.
        public static void Ejercicio6()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            Console.WriteLine($"Customers en mayuscula y minuscula;");
            Console.WriteLine(customerLogic.NombreCustomers());
            Console.ReadKey();
        }

        //7. Query para devolver Join entre Customers y Orders donde los 
        //   customers sean de Washington y la fecha de orden sea mayor a 1/1/1997.
        public static void Ejercicio7()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            Console.WriteLine("Join entre Customers y Orders");
            Console.WriteLine(customerLogic.CustomerOrder());
            Console.ReadKey();
        }

        //8. Query para devolver los primeros 3 Customers de Washington
        public static void Ejercicio8()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            Console.WriteLine("Tres Primeros Customers de Washington:");
            Console.WriteLine(customerLogic.PrimerosTresWhashington());
            Console.ReadKey();
        }

        //9.Query para devolver lista de productos ordenados por nombre
        public static void Ejercicio9()
        {
            ProductLogic productoLogic = new ProductLogic();
            Console.WriteLine("Productos ordenados por nombre");
            Console.WriteLine(productoLogic.ProductosOrdenadosNombre());
            Console.ReadKey();
        }

        //10. Query para devolver lista de productos ordenados por unit
        //    in stock de mayor a menor.
        public static void Ejercicio10()
        {
            ProductLogic productoLogic = new ProductLogic();
            CustomerLogic customerLogic = new CustomerLogic();
            Console.WriteLine($"Productos ordenados por unit in stock\n");
            Console.WriteLine(productoLogic.ProductosOrdenadosStock());
            Console.ReadKey();
        }

        //11. Query para devolver las distintas categorías asociadas a los productos
        public static void Ejercicio11()
        {
            CategoryLogic categoryLogic = new CategoryLogic();
            Console.WriteLine("Categorías asociadas a los productos\n");
            Console.WriteLine(categoryLogic.CategoriasAsociadas());
            Console.ReadKey();
        }

        //12. Query para devolver el primer elemento de una lista de productos
        public static void Ejercicio12()
        {
            ProductLogic productoLogic = new ProductLogic();
            Console.WriteLine($"Primer producto:\n");
            Console.WriteLine(productoLogic.PrimerProducto());
            Console.ReadKey();
        }

        // 13.Query para devolver los customer con la cantidad de ordenes asociadas
        public static void Ejercicio13()
        {
            CustomerLogic customerLogic = new CustomerLogic();
            Console.WriteLine($"Customers con la cantidad de ordenes asociadas");
            Console.WriteLine(customerLogic.CustomersConOrders());
            Console.ReadKey();

        }

    }
}
