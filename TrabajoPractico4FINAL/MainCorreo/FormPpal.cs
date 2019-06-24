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
        private Correo correo;

        public FormPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        //BORRAR
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormPpal_Load(object sender, EventArgs e)
        {
            //            this.lstEstadoEntregado.Text = "";
            //          this.lstEstadoEnViaje.Text = "";
            //        this.lstEstadoIngresado.Text = "";
        }

        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete auxPaquete in this.correo.Paquetes)
            {
                if (auxPaquete.Estado == Paquete.EEstado.Ingresado)
                    this.lstEstadoIngresado.Items.Add(auxPaquete);
                if (auxPaquete.Estado == Paquete.EEstado.EnViaje)
                    this.lstEstadoEnViaje.Items.Add(auxPaquete);
                if (auxPaquete.Estado == Paquete.EEstado.Entregado)
                    this.lstEstadoEntregado.Items.Add(auxPaquete);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete nuevoPaquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            nuevoPaquete.InformaEstado += paq_InformaEstado;

            try
            {
                correo += nuevoPaquete;
                this.ActualizarEstados();
            }
            catch (TrackingIdRepetidoException exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void FormPpal_FormClosing(object sender, FormClosedEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text.Guardar("Salida.txt");
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

    }
}
