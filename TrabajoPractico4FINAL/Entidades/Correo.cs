using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }
        }


        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        public void FinEntregas()
        {
            foreach(Thread auxHilo in this.mockPaquetes)
            {
                if (auxHilo.IsAlive)
                    auxHilo.Abort();
            }
        }

        //REVISAR QUE EL CASTEO FUNCIONE COMO ESPERO
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> auxPaquetes;
            auxPaquetes = ((Correo)elementos).paquetes;
            StringBuilder sb = new StringBuilder();
            foreach (Paquete p in auxPaquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }
            return sb.ToString();
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            if (c.paquetes != null)
            {
                foreach (Paquete auxPaquete in c.paquetes)
                {
                    if (auxPaquete == p)
                    {
                        throw new TrackingIdRepetidoException("El Tracking ID " + auxPaquete.TrackingID + " ya figura en la lista de envios");
                    }
                }
                c.paquetes.Add(p);
                Thread thread = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(thread);
                thread.Start();
            }

            return c;
        }

    }
}
