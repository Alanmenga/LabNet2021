using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mengassini.LINQ.Entities;
using Mengassini.LINQ.Data;

namespace Mengassini.LINQ.Logic
{
    public class CustomerLogic : LogicBase
    {
        public string CustomersWashington()
        {
            var query = from customer in context.Customers
                        where customer.Region == "Washington"
                        select customer;

            string datosCustomers = "";

            foreach (var customer in query)
            {
                datosCustomers += $" {customer.CustomerID}, {customer.ContactName}, {customer.City}\n";
            }
            return datosCustomers;
        }

        public string NombreCustomers()
        {

            var query = from customer in context.Customers
                        select new
                        {
                            nombreMayuscula = customer.ContactName.ToUpper(),
                            nombreMinuscula = customer.ContactName.ToLower()
                        };

            string datosCustomers = "";
            foreach (var customer in query)
            {
                datosCustomers += $" {customer.nombreMayuscula}, {customer.nombreMinuscula}\n";
            }
            return datosCustomers;
        }

        public string CustomerOrder()
        {
            var query = context.Customers.Where(c => c.City == "Washington")
                                         .Join(context.Orders,
                                               c => c.CustomerID,
                                               o => o.CustomerID,
                                               (c, o) => new { c.ContactName,
                                                               o.OrderID,
                                                               o.OrderDate })
                                         .Where(o => o.OrderDate > new DateTime(1997, 1, 1));

            string datosCustomers = "";
            foreach (var customer in query)
            {
                datosCustomers += $" {customer.ContactName}\n";
            }
            return datosCustomers;
        }

        public string PrimerosTresWhashington()
        {
            var query = context.Customers.Where(c => c.City == "Washington").Take(3);
            /*var query = from customer in context.Customers
                        select customer;*/

            string datosCustomers = "";
            foreach (var customer in query)
            {
                datosCustomers += $" {customer.CustomerID}, {customer.ContactName}\n";
            }
            return datosCustomers;
        }

        public string CustomersConOrders()
        {

            var query = from cus in context.Customers
                        join ord in context.Orders on cus.CustomerID equals ord.CustomerID
                        group cus by cus.ContactName into cusOrd
                        select new
                        { Nombre = cusOrd.Key, Ordenes = cusOrd.Count() };


            string datosCustomers = "";
            foreach (var customer in query)
            {
                datosCustomers += $" {customer}\n";
            }
            return datosCustomers;
        }

        public void Delete(int id)
        {
            var customerAEliminar = context.Customers.Find(id);
            context.Customers.Remove(customerAEliminar);
            context.SaveChanges();
        }

        public string GetDatos()
        {
            string datosCustomers = "CUSTOMERS: \n";
            foreach (var customer in context.Customers)
            {
                datosCustomers += $" {customer.CustomerID}, {customer.ContactName}\n";
            }

            return datosCustomers;
        }

        public Customers GetOne(string id)
        {
            return context.Customers.Find(id);
        }

        public void Insert(Customers elemento)
        {
            context.Customers.Add(elemento);
            context.SaveChanges();
        }

        public void Update(Customers elemento)
        {
            var customerUpdate = context.Customers.Find(elemento.CustomerID);
            customerUpdate.ContactName = elemento.ContactName;
            context.SaveChanges();
        }

        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }

    }
}
