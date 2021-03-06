﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                    solicitud.Problematica.Nombre = datos.lector.GetString(4);
                    solicitud.Prioridad.Nombre = datos.lector.GetString(5);
                    solicitud.FechaFin = datos.lector.GetDateTime(6);
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
                    solicitud.Problematica.ID = datos.lector.GetInt32(3);
                    solicitud.Titulo = datos.lector.GetString(4);
                    solicitud.Desc = datos.lector.GetString(5);
                    solicitud.Estado.ID = datos.lector.GetInt32(6);
                    solicitud.FechaInicio = datos.lector.GetDateTime(7);
                    solicitud.Usuario.Nombres = datos.lector.GetString(8);
                    solicitud.Usuario.Apellidos = datos.lector.GetString(9);
                    solicitud.Estado.Nombre = datos.lector.GetString(10);
                    solicitud.Prioridad.Nombre = datos.lector.GetString(11);
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
                    // PINCHA PORQUE LA LISTA NO PUEDE DEVOLVER FECHA FIN NULL
                    solicitud.FechaFin = datos.lector.GetDateTime(2);
                    solicitud.Estado.Nombre = datos.lector.GetString(3);
                    solicitud.Problematica.Nombre = datos.lector.GetString(4);
                    solicitud.Prioridad.Nombre = datos.lector.GetString(5);
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
                datos.agregarParametros("@IDProblematica", solicitud.Problematica.ID);
                datos.agregarParametros("@Titulo", solicitud.Titulo);
                datos.agregarParametros("@Descripcion", solicitud.Desc);
                datos.agregarParametros("@IDEstado", solicitud.Estado.ID);
                datos.agregarParametros("@FechaInicio", solicitud.FechaInicio);
                datos.agregarParametros("@IDPrioridad", solicitud.Prioridad.ID);
                datos.agregarParametros("@FechaFin", solicitud.FechaFin);
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
        public void solucionar(Solicitud solicitud)
        {
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                datos.SetearSP("SP_Solucionar");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@ID", solicitud.ID);
                datos.agregarParametros("@FechaFin", solicitud.FechaFin);
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
        public void cerrar(Solicitud solicitud)
        {
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                datos.SetearSP("SP_Cerrar");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@ID", solicitud.ID);
                datos.agregarParametros("@FechaFin", solicitud.FechaFin);
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
        public void comentar (Solicitud solicitud)
        {
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                datos.SetearSP("SP_Comentar");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@ID", solicitud.ID);
                datos.agregarParametros("@FechaFin", solicitud.FechaFin);
                datos.agregarParametros("@IDEstado", solicitud.Estado.ID);
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

        public void reabrir(Solicitud solicitud)
        {
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                datos.SetearSP("SP_Reabrir");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@ID", solicitud.ID);
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

        public List<Solicitud> ListarTodo()
        {
            List<Solicitud> lista = new List<Solicitud>();
            Solicitud solicitud;
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                datos.SetearQuery("SELECT S.ID, S.Titulo, S.FechaInicio, E.Nombre, P.Nombre, PRIO.Nombre,S.FechaFin, PRIO.ID, P.ID FROM Solicitudes AS S INNER JOIN Estado_de_Solicitud AS E ON e.ID = S.IDEstado INNER JOIN Prioridades AS PRIO ON PRIO.ID = S.IDPrioridad INNER JOIN Problematicas AS P ON P.ID = S.IDProblematica");
                datos.comando.Parameters.Clear();
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    solicitud = new Solicitud();
                    solicitud.ID = datos.lector.GetInt64(0);
                    solicitud.Titulo = datos.lector.GetString(1);
                    solicitud.FechaInicio = datos.lector.GetDateTime(2);
                    solicitud.Estado.Nombre = datos.lector.GetString(3);
                    solicitud.Problematica.Nombre = datos.lector.GetString(4);
                    solicitud.Prioridad.Nombre = datos.lector.GetString(5);
                    solicitud.FechaFin = datos.lector.GetDateTime(6);
                    solicitud.Prioridad.ID = datos.lector.GetInt32(7);
                    solicitud.Problematica.ID = datos.lector.GetInt32(8);
                    lista.Add(solicitud);

                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
