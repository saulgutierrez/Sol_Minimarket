﻿using System;
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
    public partial class Frm_Productos : Form
    {
        public Frm_Productos()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int Codigo_pr = 0; // Determinar el registro que debemos eliminar/actualizar
        int Codigo_um = 0;
        int Codigo_ma = 0;
        int Codigo_ca = 0;
        int Estadoguarda = 0; // Sin ninguna accion
        #endregion

        #region "Mis Metodos"
        private void Formato_pr()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CODIGO_PR";
            Dgv_principal.Columns[1].Width = 270;
            Dgv_principal.Columns[1].HeaderText = "PRODUCTO";
            Dgv_principal.Columns[2].Width = 160;
            Dgv_principal.Columns[2].HeaderText = "MARCA";
            Dgv_principal.Columns[3].Width = 150;
            Dgv_principal.Columns[3].HeaderText = "U. MEDIDA";
            Dgv_principal.Columns[4].Width = 200;
            Dgv_principal.Columns[4].HeaderText = "CATEGORIA";
            Dgv_principal.Columns[5].Width = 60;
            Dgv_principal.Columns[5].HeaderText = "STOCK MIN";
            Dgv_principal.Columns[6].Width = 60;
            Dgv_principal.Columns[6].HeaderText = "STOCK MAX";
            // Campos ocultos para enviar informacion necesaria en las tablas de la base de datos
            Dgv_principal.Columns[7].Visible = false;
            Dgv_principal.Columns[8].Visible = false;
            Dgv_principal.Columns[9].Visible = false;
        }

        private void Listado_pr(string cTexto)
        {
            try
            {
                // Cargar informacion en DataGridView
                Dgv_principal.DataSource = N_Productos.Listado_pr(cTexto);
                this.Formato_pr();
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
            if (String.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_pr"].Value)))
            {
                MessageBox.Show("No se tiene informacion para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_pr = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_pr"].Value);
                // En caso contrario, envia la informacion a la caja de texto para comenzar la edicion
                Txt_descripcion_pr.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_pr"].Value);
                this.Codigo_ma = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ma"].Value);
                // En caso contrario, envia la informacion a la caja de texto para comenzar la edicion
                Txt_descripcion_ma.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_ma"].Value);
                this.Codigo_um = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_um"].Value);
                // En caso contrario, envia la informacion a la caja de texto para comenzar la edicion
                Txt_descripcion_um.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_um"].Value);
                this.Codigo_ca = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ca"].Value);
                // En caso contrario, envia la informacion a la caja de texto para comenzar la edicion
                Txt_descripcion_ca.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_ca"].Value);
                Txt_stock_min.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["stock_min"].Value);
                Txt_stock_max.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["stock_max"].Value);
            }
        }


        private void Formato_ma_pr()
        {
            Dgv_marcas.Columns[0].Width = 258;
            Dgv_marcas.Columns[0].HeaderText = "MARCA";
            Dgv_marcas.Columns[1].Visible = false;
        }

        private void Listado_ma_pr(string cTexto)
        {
            try
            {
                // Cargar informacion en DataGridView
                Dgv_marcas.DataSource = N_Productos.Listado_ma_pr(cTexto);
                this.Formato_ma_pr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_Item_ma_pr()
        {
            // Si no hay informacion en la celda seleccionada, se lanza alerta
            if (String.IsNullOrEmpty(Convert.ToString(Dgv_marcas.CurrentRow.Cells["codigo_ma"].Value)))
            {
                MessageBox.Show("No se tiene informacion para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ma = Convert.ToInt32(Dgv_marcas.CurrentRow.Cells["codigo_ma"].Value);
                // En caso contrario, envia la informacion a la caja de texto para comenzar la edicion
                Txt_descripcion_ma.Text = Convert.ToString(Dgv_marcas.CurrentRow.Cells["descripcion_ma"].Value);
            }
        }

        private void Formato_um_pr()
        {
            Dgv_medidas.Columns[0].Width = 270;
            Dgv_medidas.Columns[0].HeaderText = "MEDIDAS";
            Dgv_medidas.Columns[1].Visible = false;
        }

        private void Listado_um_pr(string cTexto)
        {
            try
            {
                // Cargar informacion en DataGridView
                Dgv_medidas.DataSource = N_Productos.Listado_um_pr(cTexto);
                this.Formato_um_pr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_Item_um_pr()
        {
            // Si no hay informacion en la celda seleccionada, se lanza alerta
            if (String.IsNullOrEmpty(Convert.ToString(Dgv_medidas.CurrentRow.Cells["codigo_um"].Value)))
            {
                MessageBox.Show("No se tiene informacion para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_um = Convert.ToInt32(Dgv_medidas.CurrentRow.Cells["codigo_um"].Value);
                // En caso contrario, envia la informacion a la caja de texto para comenzar la edicion
                Txt_descripcion_um.Text = Convert.ToString(Dgv_medidas.CurrentRow.Cells["descripcion_um"].Value);
            }
        }


        private void Formato_ca_pr()
        {
            Dgv_categorias.Columns[0].Width = 270;
            Dgv_categorias.Columns[0].HeaderText = "CATEGORIAS";
            Dgv_categorias.Columns[1].Visible = false;
        }

        private void Listado_ca_pr(string cTexto)
        {
            try
            {
                // Cargar informacion en DataGridView
                Dgv_categorias.DataSource = N_Productos.Listado_ca_pr(cTexto);
                this.Formato_ca_pr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Selecciona_Item_ca_pr()
        {
            // Si no hay informacion en la celda seleccionada, se lanza alerta
            if (String.IsNullOrEmpty(Convert.ToString(Dgv_categorias.CurrentRow.Cells["codigo_ca"].Value)))
            {
                MessageBox.Show("No se tiene informacion para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ca = Convert.ToInt32(Dgv_categorias.CurrentRow.Cells["codigo_ca"].Value);
                // En caso contrario, envia la informacion a la caja de texto para comenzar la edicion
                Txt_descripcion_ca.Text = Convert.ToString(Dgv_categorias.CurrentRow.Cells["descripcion_ca"].Value);
            }
        }

        private void Formato_stock_actual()
        {
            Dgv_Stock_actual.Columns[0].Width = 258;
            Dgv_Stock_actual.Columns[0].HeaderText = "ALMACEN";
            Dgv_Stock_actual.Columns[1].Width = 150;
            Dgv_Stock_actual.Columns[1].HeaderText = "STOCK ACTUAL";
            Dgv_Stock_actual.Columns[2].Width = 150;
            Dgv_Stock_actual.Columns[2].HeaderText = "PU COMPRA";
        }

        private void Listado_stock_actual(int nCodigo_pr)
        {
            try
            {
                // Cargar informacion en DataGridView
                Dgv_Stock_actual.DataSource = N_Productos.Ver_Stock_actual_ProductoxAlmacenes(nCodigo_pr);
                this.Formato_stock_actual();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        #endregion

        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            // Precargar informacion almacenada en base de datos en cuanto se inicialice la aplicacion
            this.Listado_pr("%");
            this.Listado_ma_pr("%");
            this.Listado_um_pr("%");
            this.Listado_ca_pr("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_pr.Text == String.Empty ||
                Txt_descripcion_ma.Text == String.Empty ||
                Txt_descripcion_um.Text == String.Empty ||
                Txt_descripcion_ca.Text == String.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // Registro de informacion
            {
                E_Productos oPr = new E_Productos(); // Creamos un objeto de tipo almacenes para recoger los campos necesarios
                string Rpta = "";
                // Tomar datos desde la capa de presentacion
                oPr.Codigo_pr = this.Codigo_pr;
                oPr.Descripcion_pr = Txt_descripcion_pr.Text.Trim();
                oPr.Codigo_ma = this.Codigo_ma;
                oPr.Codigo_um = this.Codigo_um;
                oPr.Codigo_ca = this.Codigo_ca;
                oPr.Stock_min = Convert.ToDecimal(Txt_stock_min.Text); // Conversion de tipos
                oPr.Stock_max = Convert.ToDecimal(Txt_stock_max.Text); // Conversion de tipos
                // La vista se comunica con la capa de negocio para determinar la accion a realizar
                Rpta = N_Productos.Guardar_pr(Estadoguarda, oPr);

                // Traemos la respuesta del servidor de la capa de Datos
                if (Rpta == "OK")
                {
                    this.Listado_pr("%"); // Refrescar la vista
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Estadoguarda = 0; // Sin ninguna accion
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    Txt_descripcion_pr.Text = "";
                    Txt_stock_min.Text = "0";
                    Txt_stock_max.Text = "0";
                    Txt_descripcion_pr.ReadOnly = true;
                    Txt_stock_min.ReadOnly = true;
                    Txt_stock_max.ReadOnly = true;
                    Tbc_principal.SelectedIndex = 0;
                    this.Codigo_pr = 0;
                    Gbx_detalle.Visible = false;
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
            Gbx_detalle.Visible = false;
            this.Estado_Botonesprincipales(false); // Desactivar el resto de funciones cuando se hace clic en un boton de interaccion crud
            this.Estado_Botonesprocesos(true); // Muestra los botones de Cancelar y Guardar
            Txt_descripcion_pr.Text = "";
            Txt_stock_min.Text = "0";
            Txt_stock_max.Text = "0";
            Txt_descripcion_pr.ReadOnly = false;
            Txt_stock_min.ReadOnly = false;
            Txt_stock_max.ReadOnly = false;
            Tbc_principal.SelectedIndex = 1; // Cambiar al Tab de mantenimiento para iniciar el proceso de registro
            Txt_descripcion_pr.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; // Actualizar registro
            Gbx_detalle.Visible = false;
            this.Estado_Botonesprincipales(false); // Desactivar el resto de funciones cuando se hace clic en un boton de interaccion crud
            this.Estado_Botonesprocesos(true); // Muestra los botones de Cancelar y Guardar
            this.Selecciona_Item();  // Determinar si el registro esta seleccionado
            Tbc_principal.SelectedIndex = 1;
            Txt_descripcion_pr.ReadOnly = false;
            Txt_descripcion_pr.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 0; // Cancelar proceso
            Gbx_detalle.Visible = false;
            this.Codigo_pr = 0; // Retornar valor original del codigo seleccionado
            Txt_descripcion_pr.Text = "";
            Txt_stock_max.Text = "0";
            Txt_stock_min.Text = "0";
            Txt_descripcion_pr.ReadOnly = true;
            Txt_stock_min.ReadOnly = true;
            Txt_stock_max.ReadOnly = true;
            this.Estado_Botonesprincipales(true); // Reactiva los botones principales para realizar arcciones
            this.Estado_Botonesprocesos(false); // Oculta los botones de guardar y actualizar en la pestaña de mantenimiento
            Tbc_principal.SelectedIndex = 0; // Regresa a la pestaña de listado
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.Selecciona_Item();
            this.Estado_Botonesprocesos(false); // Desactiva los botones guardar y actualizar en la pestaña de mantenimiento
            Tbc_principal.SelectedIndex = 1; // Cambiar al Tab de mantenimiento
            this.Listado_stock_actual(this.Codigo_pr); // Mostrar informacion de stock del producto seleccionado
            // Al momento de consultar informacion, mostramos el panel de stock actual de productos
            Gbx_detalle.Visible = true;
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0; // Regresar al primer tab
            this.Codigo_pr = 0;
            Gbx_detalle.Visible = false;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            // Si no hay informacion en la celda seleccionada, se lanza alerta
            if (String.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_pr"].Value)))
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
                    this.Codigo_pr = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_pr"].Value);
                    // Enviar a ejecutar la eliminacion de datos
                    Rpta = N_Productos.Eliminar_pr(this.Codigo_pr); // Mandar la eliminacion desde la capa de presentacion a la capa de negocio
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_pr("%"); // Refrescar la vista
                        this.Codigo_pr = 0;
                        MessageBox.Show("Registro eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_pr(Txt_buscar.Text.Trim()); // Listar los textos que coincidan con el parametro enviado
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Almacenes oRpt3 = new Reportes.Frm_Rpt_Almacenes();
            oRpt3.txt_p1.Text = Txt_buscar.Text;
            oRpt3.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_lupa1_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_ma.Location = Btn_lupa1.Location;
            this.Pnl_Listado_ma.Visible = true;
        }

        private void Dgv_marcas_DoubleClick(object sender, EventArgs e)
        {
            this.Selecciona_Item_ma_pr();
            Pnl_Listado_ma.Visible = false;
        }

        private void Btn_lupa2_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_um.Location = Btn_lupa1.Location;
            this.Pnl_Listado_um.Visible = true;
        }

        private void Btn_buscar1_Click(object sender, EventArgs e)
        {
            this.Listado_ma_pr(Txt_buscar1.Text);
        }

        private void Btn_buscar2_Click(object sender, EventArgs e)
        {
            this.Listado_um_pr(Txt_buscar2.Text);
        }

        private void Btn_retornar1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_ma.Visible = false;
        }

        private void Btn_retornar2_Click(object sender, EventArgs e)
        {
            Pnl_Listado_um.Visible = false;
        }

        private void Dgv_medidas_DoubleClick(object sender, EventArgs e)
        {
            this.Selecciona_Item_um_pr();
            Pnl_Listado_um.Visible = false;
        }

        private void Btn_lupa3_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_ca.Location = Btn_lupa1.Location;
            this.Pnl_Listado_ca.Visible = true;
        }

        private void Dgv_categorias_DoubleClick(object sender, EventArgs e)
        {
            this.Selecciona_Item_ca_pr();
            Pnl_Listado_ca.Visible = false; // Desaparecer el panel cuando se haga doble clic sobre un elemento
        }

        private void Btn_buscar3_Click(object sender, EventArgs e)
        {
            this.Listado_ca_pr(Txt_buscar3.Text);
        }

        private void Btn_retornar3_Click(object sender, EventArgs e)
        {
            Pnl_Listado_ca.Visible = false;
        }
    }
}
