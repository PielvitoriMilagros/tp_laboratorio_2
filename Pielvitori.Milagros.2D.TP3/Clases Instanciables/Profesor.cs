using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        private void _randomClases()
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            clasesDelDia.Enqueue(clasesDelDia.ElementAt(random.Next(0, 3)));
            clasesDelDia.Enqueue(clasesDelDia.ElementAt(random.Next(0, 3)));
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }


        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases auxClase in i.clasesDelDia)
            {
                if (auxClase == clase)
                    return true;
            }
            return false;
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DÍA");
            if (this.clasesDelDia != null)
            {
                foreach (Universidad.EClases auxClase in this.clasesDelDia)
                {
                    sb.AppendLine(auxClase.ToString());
                }
            }

            return sb.ToString();
        }

        public Profesor() : base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            Profesor.random = new Random();
        }


        public override string ToString()
        {
            return this.MostrarDatos();
        }



    }
}
