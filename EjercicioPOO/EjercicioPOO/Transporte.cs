using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    public abstract class Transporte
    {
        //Variable
        private int cantidadPasajeros;

        //Getter y Setter
        public int CantidadPasajeros
        {
            get
            {
                return this.cantidadPasajeros;
            }
            set
            {
                this.cantidadPasajeros = value;
            }
        }

        //Constructores
        public Transporte()
        {
        
        }

        public Transporte(int cantPasaj) : this()
        {
            this.CantidadPasajeros = cantPasaj;
        }

        //Metodos
        public virtual string Avanzar()
        {
            return "El transporte esta avanzando";
        }

        public virtual string Detenerse()
        {
            return "El Transporte se detuvo";
        }

        public abstract string Mostrar();

}
}
