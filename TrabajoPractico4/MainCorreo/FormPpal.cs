using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FormPpal : Form
    {
        public FormPpal()
        {
            InitializeComponent();
        }

        //BORRAR
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormPpal_Load(object sender, EventArgs e)
        {
            this.lstEstadoEntregado.Text = "";
            this.lstEstadoEnViaje.Text = "";
            this.lstEstadoIngresado.Text = "";
        }

        //FALTA
        private void ActualizarEstados()
        { }

        //FALTA
        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        //FALTA
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {

        }

        //FALTA
        private void FormPpal_FormClosing(object sender, FormClosedEventArgs e)
        { }

        //FALTA
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        { }
        
        //FALTA
        private void paq_InformaEstado(object sender, EventArgs e)
        { }


    }
}
