using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Sol_Minimarket.Entidades;

namespace Sol_Minimarket.Datos
{
    public class D_Marcas
    {
        public DataTable Listado_ma(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            // Comunicacion con el servidor
            SqlConnection SQLCon = new SqlConnection();
            try
            {
                // Invocar al metodo de conexión el la capa de Datos
                SQLCon = Conexion.getInstancia().CrearConexion();
                // Uso de procedimiento almacenado para hacer un filtrado de las categorias activas
                SqlCommand Comando = new SqlCommand("USP_Listado_ma", SQLCon);
                Comando.CommandType = CommandType.StoredProcedure; // Establecer el tipo de consulta
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto; // Definir el parametro que se usará para filtrar en la busqueda
                SQLCon.Open();
                Resultado = Comando.ExecuteReader(); // Capturamos la informacion de busqueda
                Tabla.Load(Resultado); // Pintar el resultado de la consulta en la tabla del form
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                // Cerrar conexion
                if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
            }
        }

        public string Guardar_ma(int nOpcion, E_Marcas oMa)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Guardar_ma", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                // Definir el tipo de dato de los parametros del procedimiento almacenado y gruadar valores, utilizando el objeto
                // instanciado desde la capa de datos
                Comando.Parameters.Add("@nOpcion", SqlDbType.Int).Value = nOpcion;
                Comando.Parameters.Add("@nCodigo_ma", SqlDbType.Int).Value = oMa.Codigo_ma;
                Comando.Parameters.Add("@cDescripcion_ma", SqlDbType.VarChar).Value = oMa.Descripcion_ma;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo registrar los datos";
            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Eliminar_ma(int Codigo_ma)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Eliminar_ma", SqlCon); // Usando procedimiento almacenado para eliminacion
                Comando.CommandType = CommandType.StoredProcedure;
                // Definir el tipo de dato de los parametros del procedimiento almacenado y gruadar valores, utilizando el objeto
                // instanciado desde la capa de datos
                Comando.Parameters.Add("@nCodigo_ma", SqlDbType.Int).Value = Codigo_ma;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar los datos";
            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
    }
}
