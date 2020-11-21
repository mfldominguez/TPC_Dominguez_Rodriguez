using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PrioridadNegocio
    {
        public void alta(string nombre)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.SetearQuery("INSERT INTO Prioridades VALUES (@Nombre)");
                datos.agregarParametros("@Nombre", nombre);
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
        public void modificar(Prioridad prioridad)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.SetearQuery("UPDATE Prioridades SET Nombre = @Nombre WHERE ID = @ID");
                datos.agregarParametros("@Nombre", prioridad.Nombre);
                datos.agregarParametros("@ID", prioridad.ID);
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
        public List<Prioridad> listar()
        {

            AccesoaDatos datos = new AccesoaDatos();
            Prioridad prioridad;
            List<Prioridad> lista = new List<Prioridad>();

            try
            {
                datos.SetearQuery("SELECT * FROM Prioridades");
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    prioridad = new Prioridad();
                    prioridad.ID = datos.lector.GetInt32(0);
                    prioridad.Nombre = datos.lector.GetString(1);
                    lista.Add(prioridad);

                }
                return lista;
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
