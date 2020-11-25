using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TipoUsuariosNegocio
    {
        public List<TipoUsuarios> listar()
        {

            AccesoaDatos datos = new AccesoaDatos();
            TipoUsuarios tipo;
            List<TipoUsuarios> lista = new List<TipoUsuarios>();

            try
            {
                datos.SetearQuery("SELECT * FROM TipoUsuarios");
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    tipo = new TipoUsuarios();
                    tipo.ID = datos.lector.GetInt32(0);
                    tipo.Nombre = datos.lector.GetString(1);
                    lista.Add(tipo);

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

        public TipoUsuarios buscar(int id)
        {
            AccesoaDatos datos = new AccesoaDatos();
            TipoUsuarios tipo = new TipoUsuarios();
            try
            {
                datos.SetearQuery("SELECT * FROM TipoUsuarios WHERE ID = " + id);
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    tipo = new TipoUsuarios();
                    tipo.ID = datos.lector.GetInt32(0);
                    tipo.Nombre = datos.lector.GetString(1);
                }
                return tipo;
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
