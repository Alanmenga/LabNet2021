using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    public sealed class Automovil : Transporte
    {
        //Variables
        private string color;
        private int cantRuedas;

        //Propiedades
        public string Color
        {
            get 
            { 
                return this.color; 
            }
            set 
            { 
                this.color = value; 
            }
        }

        public int CantRuedas
        {
            get
            {
                return this.cantRuedas;
            }
            set
            {
                this.cantRuedas = value;
            }
        }

        //Constructores
        public Automovil()
           : base(0)
        {

        }
        public Automovil(int cantPasaj,string color,int cantRuedas)
            : base(cantPasaj)
        {
            this.Color = color;
            this.CantRuedas = cantRuedas;
        }

        //Metodos
        public override string Avanzar()
        {
            return "El Automovil esta arrancando";
        }

        public override string Detenerse()
        {
            return "El Automovil se apago";
        }

        public override string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("*** Datos del Automovil ***\n");
            retorno.AppendFormat("Color:                        {0}\n", this.Color);
            retorno.AppendFormat("Cantidad de Ruedas:           {0}\n", this.CantRuedas);
            retorno.AppendFormat("Cantidad de Pasajeros:        {0}\n", base.CantidadPasajeros);

            return retorno.ToString();
        }
    }
}
