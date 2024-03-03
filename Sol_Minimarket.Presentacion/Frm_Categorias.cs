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
    public partial class Frm_Categorias : Form
    {
        public Frm_Categorias()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int Codigo_ca = 0;
        int Estadoguarda = 0; // Sin ninguna accion
        #endregion

        #region "Mis Metodos"
        private void Formato_ca()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CODIGO_CA";
            Dgv_principal.Columns[1].Width = 300;
            Dgv_principal.Columns[1].HeaderText = "CATEGORIA";
        }

        private void Listado_ca(string cTexto)
        {
            try
            {
                // Cargar informacion en DataGridView
                Dgv_principal.DataSource = N_Categorias.Listado_ca(cTexto);
                this.Formato_ca();
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
            if (String.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_ca"].Value)))
            {
                MessageBox.Show("No se tiene informacion para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ca = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ca"].Value);
                // En caso contrario, envia la informacion a la caja de texto para comenzar la edicion
                Txt_descripcion_ca.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_ca"].Value);
            }
        }

        #endregion

        private void Frm_Categorias_Load(object sender, EventArgs e)
        {
            this.Listado_ca("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_ca.Text == String.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // Registro de informacion
            {
                E_Categorias oCa = new E_Categorias(); // Creamos un objeto de tipo categorias para recoger los campos necesarios
                string Rpta = "";
                // Tomar datos desde la capa de presentacion
                oCa.Codigo_ca = this.Codigo_ca;
                oCa.Descripcion_ca = Txt_descripcion_ca.Text.Trim();
                // La vista se comunica con la capa de negocio para determinar la accion a realizar
                Rpta = N_Categorias.Guardar_ca(Estadoguarda, oCa);

                // Traemos la respuesta del servidor de la capa de Datos
                if (Rpta == "OK")
                {
                    this.Listado_ca("%"); // Refrescar la vista
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Estadoguarda = 0; // Sin ninguna accion
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    Txt_descripcion_ca.Text = "";
                    Txt_descripcion_ca.ReadOnly = true;
                    Tbc_principal.SelectedIndex = 0;
                    this.Codigo_ca = 0;
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
            Txt_descripcion_ca.Text = "";
            Txt_descripcion_ca.ReadOnly = false;
            Tbc_principal.SelectedIndex = 1; // Cambiar al Tab de mantenimiento para iniciar el proceso de registro
            Txt_descripcion_ca.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; // Actualizar registro
            this.Estado_Botonesprincipales(false); // Desactivar el resto de funciones cuando se hace clic en un boton de interaccion crud
            this.Estado_Botonesprocesos(true); // Muestra los botones de Cancelar y Guardar
            this.Selecciona_Item();  // Determinar si el registro esta seleccionado
            Tbc_principal.SelectedIndex = 1;
            Txt_descripcion_ca.ReadOnly = false;
            Txt_descripcion_ca.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 0; // Cancelar proceso
            Txt_descripcion_ca.Text = "";
            Txt_descripcion_ca.ReadOnly = true;
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
        }
    }
}
