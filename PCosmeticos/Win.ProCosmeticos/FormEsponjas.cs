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

namespace Win.ProCosmeticos
{
    public partial class FormEsponjas : Form
    {
       EsponjasBL _Esponjas;

        public FormEsponjas()
        {
            InitializeComponent();

            _Esponjas = new EsponjasBL();
            listaEsponjaBindingSource.DataSource = _Esponjas.ObtenerEsponja();
        }

        private void FormEsponjas_Load(object sender, EventArgs e)
        {

        }

        private void listaEsponjaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaEsponjaBindingSource.EndEdit();  //esto es para que finalice la edicion en la funcion de guardar producto//
            var esponja = (Esponja)listaEsponjaBindingSource.Current;  //enlace para boton de guardar producto//

            var resultado = _Esponjas.GuardarEsponja(esponja);

            if (resultado.Exitoso == true)
            {
                listaEsponjaBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBottones(true);
            }
            else
                {
                     MessageBox.Show(resultado.Mensaje); // Muestra un mensaje de error//
                }

            }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _Esponjas.AgregarEsponja();
            listaEsponjaBindingSource.MoveLast();
            DeshabilitarHabilitarBottones(false);
        }

        private void DeshabilitarHabilitarBottones(bool valor)     // Función para deshabilitar botones en el menú//
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

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)      //Creando la función eliminar//
        {
            if(idTextBox.Text != "")     //Función para que no tire error cuando este vacio//
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)                  //Función para preguntar si desea eliminar el producto.//
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
                
          }
        }

        private void Eliminar(int id)
        {
            var resultado = _Esponjas.ElimanrEsponja(id);
            if (resultado == true)                             //Si el resultado es verdadero resetea o refresca la lista//
            {
                listaEsponjaBindingSource.ResetBindings(false);
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
    }
}