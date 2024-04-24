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
    public class N_Productos
    {
        public static DataTable Listado_pr(string cTexto)
        {
            D_Productos Datos = new D_Productos();
            return Datos.Listado_pr(cTexto);
        }

        // Comunicación entre la capa de interfaz con la capa de Datos
        public static string Guardar_pr(int nOpcion, E_Productos oPr)
        {
            D_Productos Datos = new D_Productos();
            return Datos.Guardar_pr(nOpcion, oPr);
        }

        // Comunicación entre la capa de interfaz con la capa de Datos
        public static string Eliminar_pr(int Codigo_pr)
        {
            D_Productos Datos = new D_Productos();
            return Datos.Eliminar_pr(Codigo_pr);
        }

        public static DataTable Listado_ma_pr(string cTexto)
        {
            D_Productos Datos = new D_Productos();
            return Datos.Listado_ma_pr(cTexto);
        }

        public static DataTable Listado_um_pr(string cTexto)
        {
            D_Productos Datos = new D_Productos();
            return Datos.Listado_um_pr(cTexto);
        }

        public static DataTable Listado_ca_pr(string cTexto)
        {
            D_Productos Datos = new D_Productos();
            return Datos.Listado_ca_pr(cTexto);
        }

        public static DataTable Ver_Stock_actual_ProductoxAlmacenes(int nCodigo_pr)
        {
            D_Productos Datos = new D_Productos();
            return Datos.Ver_Stock_actual_ProductoxAlmacenes(nCodigo_pr);
        }
    }
}
