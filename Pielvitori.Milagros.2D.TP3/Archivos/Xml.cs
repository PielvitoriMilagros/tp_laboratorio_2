using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            StreamWriter streamWriter;
            try
            {
                streamWriter = new StreamWriter(archivo);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(streamWriter, datos);
                streamWriter.Close();
                retorno = true;
            }
            catch (Exception excepcion)
            {
                throw new ArchivosException(excepcion);
            }
            /*                finally
                            {
                                streamWriter.Close();
                            }
            */
            return retorno;
        }


        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            XmlSerializer xmlSerializer;
            XmlTextReader lecturaArchivo;

            if (File.Exists(archivo))
            {
                xmlSerializer = new XmlSerializer(typeof(T));
                lecturaArchivo = new XmlTextReader(archivo);
                datos = (T)xmlSerializer.Deserialize(lecturaArchivo);
                lecturaArchivo.Close();
                retorno = true;
            }
            else
            {
                datos = default(T);
            }
            return retorno;

        }



    }
}
