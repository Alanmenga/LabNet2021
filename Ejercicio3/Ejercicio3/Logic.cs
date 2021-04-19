using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    public class Logic
    {

        /*
         * 3) Realizar un método en una clase “Logic”, llamado desde la 
         * “presentación” (Consola, UnitTest, Etc.), que dispare una 
         * excepción. La misma deberá ser capturada por la “presentación”. 
         * Deberá mostrar el mensaje de la excepción y el tipo de la 
         * excepción.
         */
        public bool fueraRangoArray()
        {
            bool retorno = false;
            int num = 5;
            int[] arr = new int[] { 4, 8, 10 };

            for (int index = 0; index <= num; index++)
            {
                Console.WriteLine(arr[index]);
                retorno = true;
            }
            return retorno;
        }

        /*      
        *4) Volver a realizar el ejercicio anterior pero esta vez la 
        *lógica deberá simplemente devolver un tipo de excepción 
        *personalizada y ser capturada por la misma aplicación.
        *Tip: Para ello se deberá agregar una clase al proyecto. 
        *Esta clase deberá heredar de tipo Excepción. La misma clase 
        *tendrá un constructor con un parámetro del tipo string donde 
        *se permitirá ingresar un mensaje personalizado. También se 
        *debe hacer una sobrecarga al “Message” Agregando algún 
        *mensaje al comienzo del mensaje de la clase base. Mostrar 
        *el mensaje de la excepción en una caja de texto.
        */
        public bool fueraRangoArray2()
        {
            //bool retorno = false;
            int num = 2;
            int[] arr = new int[] { 4, 8, 10 };

            for (int index = 0; index <= num; index++)
            {
                Console.WriteLine(arr[index]);
                //retorno = true;
            }
            throw new LogicException("Esta en mi excepcion persinalizada");
            //return retorno;
        }

    }
}
