using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
        {
            this.legajo = 0;
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        //Revisar si en la consigna con "Tipo" de universitario se refiere a nacionalidad
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg1.DNI))
                return true;
            return false;
        }


        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }


        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            if (obj is Universitario)
                return true;
            else
                return false;
        }


        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO: " + this.legajo);

            return sb.ToString();
        }





    }
}
