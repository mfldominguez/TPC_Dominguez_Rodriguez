using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProblematicasNegocio
    {

        public void alta(string nombre)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.SetearQuery("INSERT INTO Problematicas VALUES (@Nombre)");
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
        public void modificar(Problematicas problematica)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.SetearQuery("UPDATE Problematica SET Nombre = @Nombre WHERE ID = @ID");
                datos.agregarParametros("@Nombre", problematica.Nombre);
                datos.agregarParametros("@ID", problematica.ID);
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
        public List<Problematicas> listar()
        {

            AccesoaDatos datos = new AccesoaDatos();
            Problematicas problematica;
            List<Problematicas> lista = new List<Problematicas>();

            try
            {
                datos.SetearQuery("SELECT * FROM Problematicas");
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    problematica = new Problematicas();
                    problematica.ID = datos.lector.GetInt32(0);
                    problematica.Nombre = datos.lector.GetString(1);
                    lista.Add(problematica);

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
