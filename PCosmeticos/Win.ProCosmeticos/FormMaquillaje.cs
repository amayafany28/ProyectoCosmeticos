using BL.Cosmeticos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BL.Cosmeticos.MaquillajeBL;

namespace Win.ProCosmeticos
{

    public partial class FormMaquillaje : Form
    {
        MaquillajeBL _Maquillaje;

        public FormMaquillaje()
        {
            InitializeComponent();
          _Maquillaje = new MaquillajeBL();
            listaMaquillajeBindingSource.DataSource = _Maquillaje.ObtenerMaquillaje();
        }

        private void FormMaquillaje_Load(object sender, EventArgs e)
        {
            

        }

        private void descripcionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void descripcionLabel_Click(object sender, EventArgs e)
        {

        }

        private void listaMaquillajeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaMaquillajeBindingSource.EndEdit();
            var maquillaje = (Maquillaje) listaMaquillajeBindingSource.Current;  //enlace para boton de guardar producto maquillaje//

            var resultado = _Maquillaje.GuardarMaquillaje(maquillaje);

            if (resultado.Exitoso == true)
            {
                listaMaquillajeBindingSource.ResetBindings(false);  //Lo resetea porque hubo un cambio de valores en la lista//
                DeshabilitarHabilitarBottones(true);
            }

            else
            {
                MessageBox.Show(resultado.Mensaje); // Muestra un mensaje de error//
            }
        

    }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)      
        {
            _Maquillaje.AgregarMaquillaje();
            listaMaquillajeBindingSource.MoveLast();

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

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)      //enlace para boton de eliminar producto maquillaje//
        {
            if (idTextBox.Text != "")   //Función para que no tire error cuando este vacio//
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)                         //Función para preguntar si desea eliminar el producto.//
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
                
           }
        }

        private void Eliminar(int id)
        {
            var resultado = _Maquillaje.EliminarMaquillaje(id);

            if (resultado == true)                                   //Si el resultado es verdadero resetea o refresca la lista//
            {
                listaMaquillajeBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Error al eliminar Maquillaje");        // Muestra un mensaje de error//
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBottones(true);
            Eliminar(0);
        }
    }
}

