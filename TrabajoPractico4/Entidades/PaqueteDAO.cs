using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //REVISAR COMO MANEJAR LAS EXCEPTIONS
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;


        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.cadenaSQL);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }


        public static bool Insertar(Paquete p)
        {
            bool retorno = false;

            try
            {
                conexion.Open();
                comando.CommandText = "INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES ('" + p.DireccionEntrega + "','" + p.TrackingID + "','Milagros Pielvitori')";
                comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }


            return retorno;
        }

    }
}
