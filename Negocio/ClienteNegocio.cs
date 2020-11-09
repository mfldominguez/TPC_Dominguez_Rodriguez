using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            Cliente cliente;
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                datos.SetearQuery("Select * FROM VW_ListaClientes");
                datos.EjecutarLector();

                while (datos.lector.Read())
                {
                    cliente = new Cliente();
                    cliente.Estado = datos.lector.GetBoolean(3);
                    if (cliente.Estado)
                    {
                        cliente.ID = datos.lector.GetInt32(0);
                        cliente.Nombres = datos.lector.GetString(1);
                        cliente.Apellidos = datos.lector.GetString(2);
                        cliente.Direccion = datos.lector.GetString(4);
                        cliente.Telefono = datos.lector.GetString(5);
                        cliente.FechaReg = datos.lector.GetDateTime(6);

                        lista.Add(cliente);
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

        public List<Cliente> listarTODO()
        {
            List<Cliente> lista = new List<Cliente>();
            Cliente cliente;
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                datos.SetearQuery("Select * FROM VW_ListaClientes");
                datos.EjecutarLector();

                while (datos.lector.Read())
                {
                    cliente = new Cliente();
                    cliente.Estado = datos.lector.GetBoolean(3);
                    cliente.ID = datos.lector.GetInt32(0);
                    cliente.Nombres = datos.lector.GetString(1);
                    cliente.Apellidos = datos.lector.GetString(2);
                    cliente.Direccion = datos.lector.GetString(4);
                    cliente.Telefono = datos.lector.GetString(5);
                    cliente.FechaReg = datos.lector.GetDateTime(6);

                    lista.Add(cliente);

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

        public void alta(Cliente cliente)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.SetearSP("SP_Alta_Cliente");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@Nombres", cliente.Nombres);
                datos.agregarParametros("@Apellidos", cliente.Apellidos);
                datos.agregarParametros("@Estado", cliente.Estado);
                datos.agregarParametros("@Direccion", cliente.Direccion);
                datos.agregarParametros("@Telefono", cliente.Telefono);
                datos.agregarParametros("@FechaReg", cliente.FechaReg);
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

        public void modificar(Cliente cliente)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.SetearSP("SP_Modificar_Cliente");
                datos.comando.Parameters.Clear();
                datos.agregarParametros("@Nombres", cliente.Nombres);
                datos.agregarParametros("@Apellidos", cliente.Apellidos);
                datos.agregarParametros("@Estado", cliente.Estado);
                datos.agregarParametros("@Direccion", cliente.Direccion);
                datos.agregarParametros("@Telefono", cliente.Telefono);
                datos.agregarParametros("@FechaReg", cliente.FechaReg);
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

        public void inactivo(int ID)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.SetearSP("SP_Cliente_Inactivo");
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
    }

}
