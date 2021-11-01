using BL.Cosmeticos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.ProCosmeticos
{
    public partial class FormProductos : Form
    {
        ProductosBL _productos;
        public FormProductos()
        {
            InitializeComponent();
            _productos = new ProductosBL();
            listaProductosBindingSource.DataSource = _productos.ObtenerProductos();
        }

        private void listaProductosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }

        private void listaProductosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaProductosBindingSource.EndEdit();  //esto es para que finalice la edicion en la funcion de guardar producto//
            var producto = (Producto)listaProductosBindingSource.Current; //enlace para boton de guardar producto//

            if (fotoPictureBox.Image  !=null)
            {
                producto.Foto = Program.imageToByteArray(fotoPictureBox.Image);
            }
            else
            {
                producto.Foto = null;
            }
            var resultado = _productos.GuardarProducto(producto);

            if (resultado.Exitoso == true)           //Si el resultadoe es verdadero
            {
                listaProductosBindingSource.ResetBindings(false);   //Lo resetea porque hubo un cambio de valores en la lista//
                DeshabilitarHabilitarBottones(true);
                MessageBox.Show("Producto guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje); // Muestra un mensaje de error//
            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _productos.AgregarProducto();
            listaProductosBindingSource.MoveLast();
            DeshabilitarHabilitarBottones(false);
        }

        private void DeshabilitarHabilitarBottones(bool valor)  // Función para deshabilitar botones en el menú//
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")           //Función para que no tire error cuando este vacio//
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if ( resultado == DialogResult.Yes)           //Función para preguntar si desea eliminar el producto.//
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
              

        }

        private void Eliminar(int id)
        {
            var resultado = _productos.EliminarProducto(id);

            if (resultado == true)                                     //Si el resultado es verdadero resetea o refresca la lista//
            {
                listaProductosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Error al eliminar el producto");    // Muestra un mensaje de error//
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBottones(true);
            Eliminar(0);
        }

        private void fotoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var producto = (Producto)listaProductosBindingSource.Current; //enlace para boton de guardar producto//

            if (producto != null)
            {
                openFileDialog1.ShowDialog();
                var archivo = openFileDialog1.FileName;

                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);

                }
            }
           else
            {
                MessageBox.Show("Cree un producto antes de asignarle una imagen");

            } 
                


        }

        private void button2_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
 