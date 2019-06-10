using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Propiedades
        public List<Alumno> Alumnos

        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return clase; }
            set { clase = value; }
        }

        public Profesor Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }

        #endregion
        public static bool Guardar(Jornada jornada)
        {
            Texto archivoTexto = new Texto();
            return archivoTexto.Guardar("Jornada.txt", jornada.ToString());
        }


        #region Constructores
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        public string Leer()
        {
            string retorno = "";
            Texto archivoTexto = new Texto();
            archivoTexto.Leer("Jornada.txt", out retorno);
            return retorno;
        }


        #region Operadores
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno auxAlumno in j.alumnos)
            {
                if (auxAlumno == a)
                    return true;
            }
            return false;
        }


        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }


        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);
            return j;
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASE DE " + this.clase + "POR ");
            sb.AppendLine(this.instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno auxAlumno in this.alumnos)
            {
                sb.AppendLine(auxAlumno.ToString());
            }
            sb.AppendLine("<------------------------------------------------>");


            return sb.ToString();
        }


    }
}
