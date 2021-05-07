using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        Productos objetoCN = new Productos();
        private string idProducto = null;
        private bool Editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            MostrarProdctos();
            dataGridView1.Columns["PR_Id"].ReadOnly = true;
            dataGridView1.Columns["PR_Nombre"].ReadOnly = true;
            dataGridView1.Columns["PR_Marca"].ReadOnly = true;
            dataGridView1.Columns["PR_Descripcion"].ReadOnly = true;
            dataGridView1.Columns["PR_Precio"].ReadOnly = true;
            dataGridView1.Columns["PR_Stock"].ReadOnly = true;
        }

        private void MostrarProdctos() {

            Productos objeto = new Productos();
            dataGridView1.DataSource = objeto.MostrarProd();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Valida TXT
            if (string.IsNullOrEmpty(txtNombre.Text) || (string.IsNullOrEmpty(txtDesc.Text) || (string.IsNullOrEmpty(txtMarca.Text) || (string.IsNullOrEmpty(txtPrecio.Text) || (string.IsNullOrEmpty(txtStock.Text))))))
            {
                MessageBox.Show("Para actualizar debe completar todos los campos", "Sistema FCABANAS");
                return;
            }
            //Inserta productos
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarProd(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Ingreso registrado correctamente", "Sistema FCABANAS");
                    MostrarProdctos();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pueden insertar los datos por: " + ex, "Sistema FCABANAS");
                }
            }
            //Edita Productos
            if (Editar == true) {

                try
                {
                    objetoCN.EditarProd(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Se actualizo correctamente el producto seleccionado", "Sistema FCABANAS");
                    MostrarProdctos();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex) {
                    MessageBox.Show("No se pueden editar los datos por: " + ex, "Sistema FCABANAS");
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                idProducto = dataGridView1.CurrentRow.Cells["PR_Id"].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells["PR_Nombre"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["PR_Marca"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["PR_Descripcion"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["PR_Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["PR_Stock"].Value.ToString();
            }
            else
                MessageBox.Show("No se a seleccionado fila....", "Sistema FCABANAS");
        }

        private void limpiarForm() {
            txtDesc.Clear();
            txtMarca.Text = "";
            txtPrecio.Clear();
            txtStock.Clear();
            txtNombre.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["PR_id"].Value.ToString();
                objetoCN.EliminarProd(idProducto);
                MessageBox.Show("Este registro jamas Existio", "Sistema FCABANAS");
                MostrarProdctos();
            }
            else
                MessageBox.Show("No se a seleccionado fila....", "Sistema FCABANAS");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogo = MessageBox.Show("Seguro que desea Salir de la aplicacion?", "Estas apunto de salir!!!!!!", MessageBoxButtons.YesNo);
                if (dialogo == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                return;
            }
            catch
            {
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
