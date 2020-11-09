using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EstadosNegocio
    {
        public void alta(Estados estados)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.SetearQuery("INSERT INTO EstadosdeS VALUES (@Nombre)");
                datos.agregarParametros("@Nombre", estados.Nombre);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        
    }
}
