using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            StreamWriter auxArchivo = new StreamWriter(archivo);
            if(!(auxArchivo is null || datos is null ))
            {
                auxArchivo.Write(datos);
                retorno = true;
            }
            else
            {
                throw new ArchivosException(new Exception());
            }
            auxArchivo.Close();

            return retorno;
        }



        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            StreamReader lector;

            if (File.Exists(archivo))
            {
                lector = new StreamReader(archivo);
                datos = lector.ReadToEnd();
                lector.Close();
                retorno = true;
            }
            else
                datos = "";
            
            return retorno;
        }
    }
}
