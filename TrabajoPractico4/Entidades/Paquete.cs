using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {

        #region Anidados
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion

        public event DelegadoEstado InformaEstado;

        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion


        #region Propiedades
        public string DireccionEntrega
        {
            get { return direccionEntrega; }
            set { direccionEntrega = value; }
        }
        public EEstado Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public string TrackingID
        {
            get { return trackingID; }
            set { trackingID = value; }
        }
        #endregion


        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }


        //REVISAR QUE ESTE BIEN LLAMADO EL EVENTO
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000);
                this.estado++;

                this.InformaEstado(this, new EventArgs());

            } while (this.estado != EEstado.Entregado);

            PaqueteDAO.Insertar(this);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p;
            p = (Paquete)elemento;
            return string.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }


        #region Sobrecargas

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1 != null && p2 != null && p1.trackingID == p2.trackingID)
                return true;
            return false;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        #endregion


    }
}
