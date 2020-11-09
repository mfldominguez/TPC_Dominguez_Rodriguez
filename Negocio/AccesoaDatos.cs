using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoaDatos
    {
        public SqlDataReader lector { get; set; }
        public SqlConnection conexion { get; set; }
        public SqlCommand comando { get; set; }

        public AccesoaDatos()
        {
            conexion = new SqlConnection("data source=DESKTOP-EEH48JR\\SQLEXPRESS; initial catalog= TPC_Dominguez_Rodriguez; integrated security= sspi");
            comando = new SqlCommand();
            comando.Connection = conexion;
        }

        public void SetearQuery(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void agregarParametros(string parametro, object valor)
        {
            comando.Parameters.AddWithValue(parametro, valor);
        }

        public void EjecutarAccion()
        {
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EjecutarLector()
        {
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void CerrarConexion()
        {
            conexion.Close();
        }

        public void SetearSP(string SP)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = SP;
        }
    }
}
