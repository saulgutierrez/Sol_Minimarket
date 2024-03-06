using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Sol_Minimarket.Entidades;
using Sol_Minimarket.Datos;

namespace Sol_Minimarket.Negocio
{
    public class N_Marcas
    {
        public static DataTable Listado_ma(string cTexto)
        {
            D_Marcas Datos = new D_Marcas();
            return Datos.Listado_ma(cTexto);
        }

        // Comunicación entre la capa de interfaz con la capa de Datos
        public static string Guardar_ma(int nOpcion, E_Marcas oMa)
        {
            D_Marcas Datos = new D_Marcas();
            return Datos.Guardar_ma(nOpcion, oMa);
        }

        // Comunicación entre la capa de interfaz con la capa de Datos
        public static string Eliminar_ma(int Codigo_ma)
        {
            D_Marcas Datos = new D_Marcas();
            return Datos.Eliminar_ma(Codigo_ma);
        }
    }
}
