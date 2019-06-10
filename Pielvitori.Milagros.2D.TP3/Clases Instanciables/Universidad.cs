using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { this.alumnos = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return jornada; }
            set { this.jornada = value; }
        }

        public List<Profesor> Instructores
        {
            get { return profesores; }
            set { this.profesores = value; }
        }


        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }
        #endregion


        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar("Universidad.Xml", uni);      
        }


        public static Universidad Leer()
        {
            Universidad universidadLeida;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer("Universidad.Xml", out universidadLeida);
            return universidadLeida;
        }


        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach(Alumno alumno in uni.alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }

            foreach (Jornada jornada in uni.jornada)
            {
                sb.AppendLine(jornada.ToString());
            }

            foreach (Profesor profesor in uni.profesores)
            {
                sb.AppendLine(profesor.ToString());
            }

            return sb.ToString();
        }


        public override string ToString()
        {
            return MostrarDatos(this);
        }


        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }


        #region Operadores

        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno auxAlumno in g.alumnos)
            {
                if (auxAlumno == a)
                    return true;
            }
            return false;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Jornada auxProfesor in g.jornada)
            {
                if (auxProfesor.Instructor == i)
                    return true;
            }
            return false;
        }

        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Jornada auxJornada in g.jornada)
            {
                if (auxJornada.Clase == clase)
                {
                    foreach (Profesor auxProf in g.profesores)
                    {
                        if (auxProf == clase)
                            return auxProf;
                    }

                }
            }
            throw new SinProfesorException();
        }


        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Jornada auxJornada in g.jornada)
            {
                if (auxJornada.Clase == clase)
                {
                    foreach (Profesor auxProf in g.profesores)
                    {
                        if (auxProf != clase)
                            return auxProf;
                    }
                }
            }
            return null;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada nuevaJornada;
            if (g.profesores.Count == 0)
            {
                throw new SinProfesorException();
            }
            else
            {
                nuevaJornada = new Jornada(clase, g == clase);
                foreach (Alumno auxAlumno in g.alumnos)
                {
                    if (auxAlumno == clase)
                        nuevaJornada.Alumnos.Add(auxAlumno);
                }
                g.jornada.Add(nuevaJornada);

            }

            return g;
        }


        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
                g.alumnos.Add(a);

            return g;
        }


        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
                g.profesores.Add(i);

            return g;
        }

        #endregion


    }
}
