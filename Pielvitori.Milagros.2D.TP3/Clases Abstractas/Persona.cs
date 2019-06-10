using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;


namespace Clases_Abstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;


        public Persona()
        {
            this.apellido = "";
            this.nombre = "";
            this.dni = 0;
        }

        public Persona(string nombre,string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad): this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }



        public ENacionalidad Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get { return apellido; }
            set
            {
                apellido = ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get { return dni; }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        public string StringToDNI
        {
            set
            {
                ValidarDni(this.nacionalidad, value);
            }
        }


        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return ValidarDni(nacionalidad, dato.ToString());
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int auxDni = 0;
            // Verificar si para la segunda parte de este IF ya está cargado auxDni
            if (int.TryParse(dato, out auxDni) && auxDni > 0 && auxDni < 99999999)
            {
                if (nacionalidad == ENacionalidad.Argentino && auxDni > 89999999)
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
                if (nacionalidad == ENacionalidad.Extranjero && auxDni < 90000000)
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }
            else
            {
                throw new DniInvalidoException();
            }
            return auxDni;
        }


        private static string ValidarNombreApellido(string dato)
        {
            if (dato.All(char.IsLetter))
                return dato;
            return "";
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: "+this.apellido+", "+this.nombre);
            sb.AppendLine("NACIONALIDAD: "+this.nacionalidad);

            return sb.ToString();
        }


    }
}
