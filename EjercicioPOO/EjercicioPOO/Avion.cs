using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    public sealed class Avion : Transporte
    {
        //Variables
        private string color;
        private int cantTurbinas;

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

        public int CantTurbinas
        {
            get
            {
                return this.cantTurbinas;
            }
            set
            {
                this.cantTurbinas = value;
            }
        }

        //Constructores
        public Avion()
            :base(0)
        {

        }

        public Avion(int cantPasaj, string color, int cantTurbinas)
            : base(cantPasaj)
        {
            this.Color = color;
            this.CantTurbinas = cantTurbinas;
        }

        //Metodos
        public override string Avanzar()
        {
            return "El Avion esta por despegar";
        }

        public override string Detenerse()
        {
            return "El Avion esta aterrizando";
        }

        public override string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("*** Datos del Avion ***\n");
            retorno.AppendFormat("Color:                        {0}\n", this.Color);
            retorno.AppendFormat("Cantidad de Turbinas:         {0}\n", this.CantTurbinas);
            retorno.AppendFormat("Cantidad de Pasajeros:        {0}\n", base.CantidadPasajeros);

            return retorno.ToString();
        }
    }
}
