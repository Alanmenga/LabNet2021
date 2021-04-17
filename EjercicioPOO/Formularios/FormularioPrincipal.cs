using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EjercicioPOO;

namespace Formularios
{
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        //Seccion Auto
        private void buttonLimpiarAuto_Click(object sender, EventArgs e)
        {
            textBoxCAuto.Text = "";
            textBoxCPAuto.Text = "";
            textBoxCRAuto.Text = "";
            richTextBoxDatosAuto.Text = "";
            textBoxDetenerAuto.Text = "";
            textBoxAvanzarAuto.Text = "";
        }

        private void buttonAgregarAuto_Click(object sender, EventArgs e)
        {
            if (textBoxCAuto.Text != "" && textBoxCPAuto.Text != "" && textBoxCRAuto.Text != "")
            {
                Automovil auto = new Automovil(int.Parse(textBoxCPAuto.Text), textBoxCAuto.Text, int.Parse(textBoxCRAuto.Text));
                richTextBoxDatosAuto.Text = auto.Mostrar();
            }
            else
            {
                richTextBoxDatosAuto.Text = "Faltan completar datos.";
            }
        }

        private void buttonAvanzarAuto_Click(object sender, EventArgs e)
        {
            if (textBoxCAuto.Text != "" && textBoxCPAuto.Text != "" && textBoxCRAuto.Text != "")
            {
                Automovil auto = new Automovil();
                textBoxAvanzarAuto.Text = auto.Avanzar();
            }
            else
            {
                textBoxAvanzarAuto.Text = "No hay cargado un automovil";
            }
        }

        private void buttonDetenerAuto_Click(object sender, EventArgs e)
        {
            if (textBoxCAuto.Text != "" && textBoxCPAuto.Text != "" && textBoxCRAuto.Text != "")
            {
                Automovil auto = new Automovil();
                textBoxDetenerAuto.Text = auto.Detenerse();
            }
            else
            {
                textBoxDetenerAuto.Text = "No hay cargado un automovil";
            }
        }

        //Seccion Avion
        private void buttonLimpiarAvion_Click(object sender, EventArgs e)
        {
            textBoxCAvion.Text = "";
            textBoxCPAvion.Text = "";
            textBoxCTAvion.Text = "";
            richTextBoxDatosAvion.Text = "";
            textBoxAvanzarAvion.Text = "";
            textBoxDetenerAvion.Text = "";
        }


        private void buttonAgregarAvion_Click(object sender, EventArgs e)
        {
            if (textBoxCAvion.Text != "" && textBoxCPAvion.Text != "" && textBoxCTAvion.Text != "")
            {
                Avion avion = new Avion(int.Parse(textBoxCPAvion.Text), textBoxCAvion.Text, int.Parse(textBoxCTAvion.Text));
                richTextBoxDatosAvion.Text = avion.Mostrar();
            }
            else
            {
                richTextBoxDatosAuto.Text = "Faltan completar datos.";
            }
        }

        private void buttonAvanzarAvion_Click(object sender, EventArgs e)
        {
            if (textBoxCAvion.Text != "" && textBoxCPAvion.Text != "" && textBoxCTAvion.Text != "")
            {
                Avion avion = new Avion();
                textBoxAvanzarAvion.Text = avion.Avanzar();
            }
            else
            {
                textBoxAvanzarAvion.Text = "No hay cargado un avion";
            }

        }

        private void buttonDetenerAvion_Click(object sender, EventArgs e)
        {
            if (textBoxCAvion.Text != "" && textBoxCPAvion.Text != "" && textBoxCTAvion.Text != "")
            {
                Avion avion = new Avion();
                textBoxDetenerAvion.Text = avion.Detenerse();
            }
            else
            {
                textBoxDetenerAvion.Text = "No hay cargado un avion";
            }

        }


        
    }
}
