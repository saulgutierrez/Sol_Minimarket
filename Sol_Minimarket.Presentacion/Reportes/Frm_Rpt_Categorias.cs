using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_Minimarket.Presentacion.Reportes
{
    public partial class Frm_Rpt_Categorias : Form
    {
        public Frm_Rpt_Categorias()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Categorias_Load(object sender, EventArgs e)
        {
            // Enviar parametro de filtrado hacia el objeto TableAdapter, utilizado en el sistema de reporte
            // La variable cTexto viene con un parametro, que es una caja de texto vacia dentro del reporte,
            // para que la en la informacion vaciada en el reporte no exista ningun tipo de filtrado
            this.uSP_Listado_caTableAdapter.Fill(this.dataSet_MiniMarket.USP_Listado_ca, cTexto:txt_p1.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
