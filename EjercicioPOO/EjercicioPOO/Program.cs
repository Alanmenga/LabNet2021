using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creo las colecciones
            List<Automovil> autos = new List<Automovil>();
            List<Avion> aviones = new List<Avion>();

            //Creo los autos
            Automovil Audi = new Automovil(4, "rojo", 4);
            Automovil Renault = new Automovil(8, "azul", 4);
            Automovil Ford = new Automovil(6, "violeta", 6);
            Automovil Chevrolet = new Automovil(10, "negro", 8);
            Automovil Fiat = new Automovil(2, "gris", 4);

            //Agrego los autos a la coleccion
            autos.Add(Audi);
            autos.Add(Renault);
            autos.Add(Ford);
            autos.Add(Chevrolet);
            autos.Add(Fiat);

            //Recorro la coleccion
            foreach (var item in autos)
            {
                Console.WriteLine(item.Mostrar());
            }

            //Creo los aviones
            Avion A300 = new Avion(260, "blanco", 2);
            Avion A301 = new Avion(100, "gris", 2);
            Avion A302 = new Avion(200, "azul", 4);
            Avion A303 = new Avion(150, "rojo", 2);
            Avion A304 = new Avion(300, "blanco", 4);

            //Agrego los aviones a la coleccion
            aviones.Add(A300);
            aviones.Add(A301);
            aviones.Add(A302);
            aviones.Add(A303);
            aviones.Add(A304);

            //Recorro la coleccion
            foreach (var item in aviones)
            {
                Console.WriteLine(item.Mostrar());
            }

            //Muestro los metodos de las clases heredadas
            Console.WriteLine(Audi.Avanzar());
            Console.WriteLine(Audi.Detenerse());
            Console.WriteLine(A300.Avanzar());
            Console.WriteLine(A300.Detenerse());
        }
    }
}
