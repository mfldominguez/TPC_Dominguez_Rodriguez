using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class SintomasNegocio
    {

        public void alta(string nombre)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.SetearQuery("INSERT INTO Sintomas VALUES (@Nombre)");
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
        public void modificar(Sintomas sintoma)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.SetearQuery("UPDATE Sintomas SET Nombre = @Nombre WHERE ID = @ID");
                datos.agregarParametros("@Nombre", sintoma.Nombre);
                datos.agregarParametros("@ID", sintoma.ID);
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
        public List<Sintomas> listar()
        {

            AccesoaDatos datos = new AccesoaDatos();
            Sintomas sintoma;
            List<Sintomas> lista = new List<Sintomas>();

            try
            {
                datos.SetearQuery("SELECT * FROM Sintomas");
                datos.EjecutarLector();
                while (datos.lector.Read())
                {
                    sintoma = new Sintomas();
                    sintoma.ID = datos.lector.GetInt32(0);
                    sintoma.Nombre = datos.lector.GetString(1);
                    lista.Add(sintoma);

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
