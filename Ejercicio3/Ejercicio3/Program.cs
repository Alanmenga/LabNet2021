using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            Metodos metodo = new Metodos();

            //**************EJERCICIO 1***********************
            Console.WriteLine("**************EJERCICIO 1***********************");
            Console.Write("Ingrese un numero: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            metodo.DivisionXCero(numero);
            //Console.WriteLine(DivisionXCero(numero));

            //**************EJERCICIO 2***********************
            Console.WriteLine("**************EJERCICIO 2***********************");
            Console.Write("Ingrese un numero: ");
            int numero1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese otro numero: ");
            int numero2 = Convert.ToInt32(Console.ReadLine());
            metodo.DivisionXCero2(numero1, numero2);
            //Console.WriteLine(DivisionXCero2(numero1,numero2));

            //**************EJERCICIO 3***********************
            Console.WriteLine("**************EJERCICIO 3***********************");
            try
            {
                Logic logica = new Logic();
                logica.fueraRangoArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.GetType());
            }

            //**************EJERCICIO 4***********************
            Console.WriteLine("**************EJERCICIO 4***********************");
            try
            {
                Logic logica = new Logic();
                logica.fueraRangoArray2();
            }
            catch (LogicException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.GetType());
            }


        } 
    }
}
