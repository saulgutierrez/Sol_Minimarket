using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sol_Minimarket.Entidades;
using Sol_Minimarket.Negocio;

namespace Sol_Minimarket.Presentacion
{
    public partial class Frm_Marcas : Form
    {
        public Frm_Marcas()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int Codigo_ma = 0; // Determinar el registro que debemos eliminar/actualizar
        int Estadoguarda = 0; // Sin ninguna accion
        #endregion

        #region "Mis Metodos"
        private void Formato_ma()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CODIGO_MA";
            Dgv_principal.Columns[1].Width = 300;
            Dgv_principal.Columns[1].HeaderText = "MARCA";
        }

        private void Listado_ma(string cTexto)
        {
            try
            {
                // Cargar informacion en DataGridView
                Dgv_principal.DataSource = N_Marcas.Listado_ma(cTexto);
                this.Formato_ma();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Estado_Botonesprincipales(bool lEstado)
        {
            // Activar o desactivar botones de acuerdo al estodo
            this.Btn_nuevo.Enabled = lEstado;
            this.Btn_actualizar.Enabled = lEstado;
            this.Btn_eliminar.Enabled = lEstado;
            this.Btn_reporte.Enabled = lEstado;
            this.Btn_salir.Enabled = lEstado;
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            this.Btn_cancelar.Visible = lEstado;
            this.Btn_guardar.Visible = lEstado;
            this.Btn_retornar.Visible = !lEstado;
        }

        private void Selecciona_Item()
        {
            // Si no hay informacion en la celda seleccionada, se lanza alerta
            if (String.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_ma"].Value)))
            {
                MessageBox.Show("No se tiene informacion para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ma = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ma"].Value);
                // En caso contrario, envia la informacion a la caja de texto para comenzar la edicion
                Txt_descripcion_ma.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_ma"].Value);
            }
        }

        #endregion

        private void Frm_Marcas_Load(object sender, EventArgs e)
        {
            this.Listado_ma("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_ma.Text == String.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // Registro de informacion
            {
                E_Marcas oMa = new E_Marcas(); // Creamos un objeto de tipo categorias para recoger los campos necesarios
                string Rpta = "";
                // Tomar datos desde la capa de presentacion
                oMa.Codigo_ma = this.Codigo_ma;
                oMa.Descripcion_ma = Txt_descripcion_ma.Text.Trim();
                // La vista se comunica con la capa de negocio para determinar la accion a realizar
                Rpta = N_Marcas.Guardar_ma(Estadoguarda, oMa);

                // Traemos la respuesta del servidor de la capa de Datos
                if (Rpta == "OK")
                {
                    this.Listado_ma("%"); // Refrescar la vista
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Estadoguarda = 0; // Sin ninguna accion
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    Txt_descripcion_ma.Text = "";
                    Txt_descripcion_ma.ReadOnly = true;
                    Tbc_principal.SelectedIndex = 0;
                    this.Codigo_ma = 0;
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Estadoguarda = 1; // Nuevo registro
            this.Estado_Botonesprincipales(false); // Desactivar el resto de funciones cuando se hace clic en un boton de interaccion crud
            this.Estado_Botonesprocesos(true); // Muestra los botones de Cancelar y Guardar
            Txt_descripcion_ma.Text = "";
            Txt_descripcion_ma.ReadOnly = false;
            Tbc_principal.SelectedIndex = 1; // Cambiar al Tab de mantenimiento para iniciar el proceso de registro
            Txt_descripcion_ma.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; // Actualizar registro
            this.Estado_Botonesprincipales(false); // Desactivar el resto de funciones cuando se hace clic en un boton de interaccion crud
            this.Estado_Botonesprocesos(true); // Muestra los botones de Cancelar y Guardar
            this.Selecciona_Item();  // Determinar si el registro esta seleccionado
            Tbc_principal.SelectedIndex = 1;
            Txt_descripcion_ma.ReadOnly = false;
            Txt_descripcion_ma.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 0; // Cancelar proceso
            this.Codigo_ma = 0; // Retornar valor original del codigo seleccionado
            Txt_descripcion_ma.Text = "";
            Txt_descripcion_ma.ReadOnly = true;
            this.Estado_Botonesprincipales(true); // Reactiva los botones principales para realizar arcciones
            this.Estado_Botonesprocesos(false); // Oculta los botones de guardar y actualizar en la pestaña de mantenimiento
            Tbc_principal.SelectedIndex = 0; // Regresa a la pestaña de listado
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.Selecciona_Item();
            this.Estado_Botonesprocesos(false); // Desactiva los botones guardar y actualizar en la pestaña de mantenimiento
            Tbc_principal.SelectedIndex = 1; // Cambiar al Tab de mantenimiento
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0; // Regresar al primer tab
            this.Codigo_ma = 0;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            // Si no hay informacion en la celda seleccionada, se lanza alerta
            if (String.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_ma"].Value)))
            {
                MessageBox.Show("No se tiene informacion para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Esta seguro de eliminar el registro seleccionado", "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Opcion == DialogResult.Yes)
                {
                    String Rpta = "";
                    // Guardar codigo de objeto seleccionado
                    this.Codigo_ma = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ma"].Value);
                    // Enviar a ejecutar la eliminacion de datos
                    Rpta = N_Marcas.Eliminar_ma(this.Codigo_ma); // Mandar la eliminacion desde la capa de presentacion a la capa de negocio
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_ma("%"); // Refrescar la vista
                        this.Codigo_ma = 0;
                        MessageBox.Show("Registro eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_ma(Txt_buscar.Text.Trim()); // Listar los textos que coincidan con el parametro enviado
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Marcas oRpt2 = new Reportes.Frm_Rpt_Marcas();
            oRpt2.txt_p1.Text = Txt_buscar.Text;
            oRpt2.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
