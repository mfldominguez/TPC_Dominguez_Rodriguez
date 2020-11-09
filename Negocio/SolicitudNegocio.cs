using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class SolicitudNegocio
    {
        public List<Solicitud> Listar_en_perfil_abiertas(int IDCliente)
        {
            List<Solicitud> lista = new List<Solicitud>();
            Solicitud solicitud;
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                datos.SetearSP("SP_ListaSolicitud_Abierta");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@IDCliente", IDCliente);
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    solicitud = new Solicitud();
                    solicitud.ID = datos.lector.GetInt64(0);
                    solicitud.Titulo = datos.lector.GetString(1);
                    solicitud.FechaInicio = datos.lector.GetDateTime(2);
                    solicitud.Estado.Nombre = datos.lector.GetString(3);
                    solicitud.Sintoma.Nombre = datos.lector.GetString(4);
                    lista.Add(solicitud);

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

        public Solicitud mostrar_abiertas(long idsolicitud)
        {
            Solicitud solicitud;
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                solicitud = new Solicitud();
                datos.SetearSP("SP_Solicitud");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@ID", idsolicitud);
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    solicitud.ID = datos.lector.GetInt64(0);
                    solicitud.Cliente.ID = datos.lector.GetInt32(1);
                    solicitud.Usuario.ID = datos.lector.GetInt64(2);
                    solicitud.Sintoma.ID = datos.lector.GetInt32(3);
                    solicitud.Titulo = datos.lector.GetString(4);
                    solicitud.Desc = datos.lector.GetString(5);
                    solicitud.Estado.ID = datos.lector.GetInt32(6);
                    solicitud.FechaInicio = datos.lector.GetDateTime(7);
                    solicitud.Usuario.Nombres = datos.lector.GetString(8);
                    solicitud.Usuario.Apellidos = datos.lector.GetString(9);
                    solicitud.Estado.Nombre = datos.lector.GetString(10);
                }
                return solicitud;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Solicitud> Listar_en_perfil_cerradas(int IDCliente)
        {
            List<Solicitud> lista = new List<Solicitud>();
            Solicitud solicitud;
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                datos.SetearSP("SP_ListaSolicitud_Cerrada");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@IDCliente", IDCliente);
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    solicitud = new Solicitud();
                    solicitud.ID = datos.lector.GetInt64(0);
                    solicitud.Titulo = datos.lector.GetString(1);
                    solicitud.FechaFin = datos.lector.GetDateTime(3);
                    solicitud.Estado.Nombre = datos.lector.GetString(4);
                    solicitud.Sintoma.Nombre = datos.lector.GetString(5);
                    lista.Add(solicitud);

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

        public void Alta(Solicitud solicitud)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.SetearSP("SP_Alta_Solicitud");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@IDCliente", solicitud.Cliente.ID);
                datos.agregarParametros("@IDUsuario", solicitud.Usuario.ID);
                datos.agregarParametros("@IDSintoma", solicitud.Sintoma.ID);
                datos.agregarParametros("@Titulo", solicitud.Titulo);
                datos.agregarParametros("@Descripcion", solicitud.Desc);
                datos.agregarParametros("@IDEstado", solicitud.Estado.ID);
                datos.agregarParametros("@FechaInicio", solicitud.FechaInicio);
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
