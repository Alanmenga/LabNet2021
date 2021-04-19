using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    public class Metodos
    {
        //**************METODOS***********************
        /* 
         * 1) Realizar una método que al ingresar un valor genere una 
         * simple excepción al intentar hacer una división por cero. 
         * Esta misma excepción deberá ser capturada, mostrando el 
         * mensaje de la excepción y siempre deberá avisar cuando 
         * terminó de realizarse la operación haya sido exitosa o no.
         */
        public bool DivisionXCero(int num)
        {
            bool retorno = false;
            try
            {
                Console.WriteLine(num / 0);
                retorno = true;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Termino la operacion.");
            }
            return retorno;
        }


        /*  
         *  2) Realizar un método que permita ingresar 2 números 
         *  (dividendo y divisor) y realice la división de los mismos.
         *  Se deberán mostrar el resultado (Si es un Unit Test tener 
         *  en cuenta los Assert). 
         *  Si hay una excepción de división por cero se deberá mostrar
         *  el siguiente mensaje: “Solo Chuck Norris divide por cero!” 
         *  (Se acepta todo tipo de creatividad) más el mensaje de la 
         *  excepción propia. También se deberá capturar una excepción 
         *  si el usuario no ingresa ningún número o el mismo no es un 
         *  número válido, informando la situación de “Seguro Ingreso 
         *  una letra o no ingreso nada!”.
         */
        public bool DivisionXCero2(int num1, int num2)
        {
            bool retorno = false;
            try
            {
                Console.WriteLine(num1 / num2);
                retorno = true;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Ni Stephen Hawking te hubiera podido resolver esa cuenta");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Dato ingresado no valido");
            }
            finally
            {
                Console.WriteLine("Termino la operacion.");
            }
            return retorno;
        }
    }
}

