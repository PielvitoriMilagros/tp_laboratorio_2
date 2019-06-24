using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Entidades
{
    public static class GuardaString
    {
        //REVISAR COMO HACER QUE VAYA AL ESCRITORIO
        public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter auxArchivo = null;
            bool retorno = false;
            try
            {
                auxArchivo = new StreamWriter(archivo);
                if (!(auxArchivo is null))
                {
                    auxArchivo.WriteLine(texto);
                    retorno = true;
                }
                else
                {
                    throw (new Exception());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (auxArchivo != null)
                    auxArchivo.Close();
            }

            return retorno;
        }
    }
}