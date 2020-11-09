using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuariosNegocio
    {
        public List<Usuario> Listar()
        {
            AccesoaDatos datos = new AccesoaDatos();
            List<Usuario> lista = new List<Usuario>();
            Usuario usuario;
            try
            {
                datos.SetearQuery("Select * FROM VW_ListaUsuarios");
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    usuario = new Usuario();
                    usuario.Estado = datos.lector.GetBoolean(6);
                    if (usuario.Estado)
                    {
                        usuario.ID = datos.lector.GetInt64(0);
                        usuario.NombreUsuario = datos.lector.GetString(2);
                        usuario.Contraseña = datos.lector.GetString(3);
                        usuario.Nombres = datos.lector.GetString(4);
                        usuario.Apellidos = datos.lector.GetString(5);
                        usuario.Tipo = datos.lector.GetString(7);

                        lista.Add(usuario);
                    }
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

        public List<Usuario> ListarTODO()
        {
            AccesoaDatos datos = new AccesoaDatos();
            List<Usuario> lista = new List<Usuario>();
            Usuario usuario;
            try
            {
                datos.SetearQuery("Select * FROM VW_ListaUsuarios");
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    usuario = new Usuario();
                    usuario.Estado = datos.lector.GetBoolean(6);
                    usuario.ID = datos.lector.GetInt64(0);
                    usuario.NombreUsuario = datos.lector.GetString(2);
                    usuario.Contraseña = datos.lector.GetString(3);
                    usuario.Nombres = datos.lector.GetString(4);
                    usuario.Apellidos = datos.lector.GetString(5);
                    usuario.Tipo = datos.lector.GetString(7);

                    lista.Add(usuario);

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

        public Usuario validarUsuario(string nombreusuario, string contraseña)
        {
            AccesoaDatos datos = new AccesoaDatos();
            Usuario usuario = new Usuario();
            try
            {
                datos.SetearSP("SP_Validar_Usuario");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@NombreU", nombreusuario);
                datos.agregarParametros("@Contraseña", contraseña);
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    usuario.Estado = datos.lector.GetBoolean(6);
                    if (usuario.Estado)
                    {
                        usuario.ID = datos.lector.GetInt64(0);
                        usuario.Tipo = datos.lector.GetString(7);
                        usuario.NombreUsuario = datos.lector.GetString(2);
                        usuario.Contraseña = datos.lector.GetString(3);
                        usuario.Nombres = datos.lector.GetString(4);
                        usuario.Apellidos = datos.lector.GetString(5);
                    }

                }
                return usuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Alta(Usuario usuario)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.SetearSP("SP_Alta_Usuario");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@IDTipodeusuario", usuario.Tipo);
                datos.agregarParametros("@NombreU", usuario.NombreUsuario);
                datos.agregarParametros("@Contraseña", usuario.Contraseña);
                datos.agregarParametros("@Nombres", usuario.Nombres);
                datos.agregarParametros("@Apellidos", usuario.Apellidos);
                datos.agregarParametros("@Estado", usuario.Estado);
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

        public void inactivar(long ID)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.SetearSP("SP_Usuario_Inactivo");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@ID", ID);
                datos.agregarParametros("@Estado", 0);
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

        public void modificar(Usuario usuario)
        {
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                datos.SetearSP("SP_Modificar_Usuario");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@ID", usuario.ID);
                datos.agregarParametros("@IDTipodeusuario", usuario.Tipo);
                datos.agregarParametros("@NombreU", usuario.NombreUsuario);
                datos.agregarParametros("@Contraseña", usuario.Contraseña);
                datos.agregarParametros("@Nombres", usuario.Nombres);
                datos.agregarParametros("@Apellidos", usuario.Apellidos);
                datos.agregarParametros("@Estado", usuario.Estado);
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
