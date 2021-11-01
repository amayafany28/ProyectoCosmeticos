using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Cosmeticos
{
    public class EsponjasBL
    {
        public BindingList<Esponja> ListaEsponja { get; set; }
        public EsponjasBL()
        {
            ListaEsponja = new BindingList<Esponja>();

            var Esponja1 = new Esponja();
            Esponja1.Id = 1;
            Esponja1.Descripcion = "Esponja con Base";
            Esponja1.Precio = 100;
            Esponja1.Existencia = 20;
            Esponja1.Activo = true;

            ListaEsponja.Add(Esponja1);


            var Esponja2 = new Esponja();
            Esponja2.Id = 2;
            Esponja2.Descripcion = "Beauty Creations Blending Sponge w/soap";
            Esponja2.Precio = 150;
            Esponja2.Existencia = 15;
            Esponja2.Activo = true;

            ListaEsponja.Add(Esponja2);

            var Esponja3 = new Esponja();
            Esponja3.Id = 3;
            Esponja3.Descripcion = " Esponjas Puff Maquillaje Kylie Cosmetics ";
            Esponja3.Precio = 270;
            Esponja3.Existencia = 15;
            Esponja3.Activo = true;

            ListaEsponja.Add(Esponja3);


       
        }
        public BindingList<Esponja> ObtenerEsponja()
        {
            return ListaEsponja;
        }

        public Resultad GuardarEsponja(Esponja esponja)  //Creando la clase guardar producto//
        {
            var resultado = Validar(esponja);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }
            if (esponja.Id == 0)
            {
                esponja.Id = ListaEsponja.Max(item => item.Id) + 1;     //Busca el número mayor y le suma 1//
            }
            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarEsponja()          //Creando la funcion agregar nuevo producto//
        {
            var nuevoEsponja = new Esponja();
            ListaEsponja.Add(nuevoEsponja);
        }


        public bool ElimanrEsponja (int id)   //Creando la función eliminar //
        {
            foreach (var esponja in ListaEsponja)
            {
                if (esponja.Id == id)
                {                               //Ciclo para buscar el producto deseado y luego ser borrado//
                    ListaEsponja.Remove(esponja);
                    return true;
            }
        }
            return false;
       }

        private Resultad Validar(Esponja esponja)  // Función para Validaciones//

        {
            var resultado = new Resultad();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(esponja.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una descripción";
                resultado.Exitoso = false;
            }
            if (esponja.Existencia < 0)
            {
                resultado.Mensaje = "La existencia debe ser mayor que cero";
                resultado.Exitoso = false;
            }
            if (esponja.Precio < 0)
            {
                resultado.Mensaje = "El precio debe ser mayor que cero";
                resultado.Exitoso = false;
            }

            return resultado;
        }


    }

    public class Esponja
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; }
    }

    public class Resultad                 //Se creo la clase de Resultado//
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }

}
