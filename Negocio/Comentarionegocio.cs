using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ComentarioNegocio
    {
        public void alta(Comentarios comentarios)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.SetearSP("SP_Alta_Comentario");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@IDSolicitud", comentarios.solicitud.ID);
                datos.agregarParametros("@IDUsuario", comentarios.Usuario.ID);
                datos.agregarParametros("@Comentario", comentarios.Comentario);
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

        public List<Comentarios> listardesolicitud(long idsolicitud)
        {
            List<Comentarios> lista = new List<Comentarios>();
            Comentarios comentarios;
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                datos.SetearSP("SP_Listar_Comentarios");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@IDSolicitud", idsolicitud);
                datos.EjecutarLector();
                comentarios = new Comentarios();
                while (datos.lector.Read())
                {
                    comentarios = new Comentarios();
                    comentarios.ID = datos.lector.GetInt64(0);
                    comentarios.Usuario.ID = datos.lector.GetInt64(1);
                    comentarios.Usuario.Nombres = datos.lector.GetString(2);
                    comentarios.Usuario.Apellidos = datos.lector.GetString(3);
                    comentarios.Comentario = datos.lector.GetString(4);
                    lista.Add(comentarios);
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
