using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Cosmeticos
{
    public class MaquillajeBL
    {
        
 
        public BindingList<Maquillaje > ListaMaquillaje { get; set; }

        public MaquillajeBL()
        {
            ListaMaquillaje = new BindingList<Maquillaje>();

            var Maquillaje1 = new Maquillaje();
            Maquillaje1.Id = 1;
            Maquillaje1.Descripcion = "BEAUTE CREATIONS Paleta Tease Me";
            Maquillaje1.Precio = 250;
            Maquillaje1.Existencia = 15;
            Maquillaje1.Activo = true;

            ListaMaquillaje.Add(Maquillaje1);

            var Maquillaje2 = new Maquillaje();
            Maquillaje2.Id = 2;
            Maquillaje2.Descripcion = "AMORUS Paleta Nude Fantasía";
            Maquillaje2.Precio = 440;
            Maquillaje2.Existencia = 15;
            Maquillaje2.Activo = true;

            ListaMaquillaje.Add(Maquillaje2);

            var Maquillaje3 = new Maquillaje();
            Maquillaje3.Id = 3;
            Maquillaje3.Descripcion = " KTB Bases Stay All Day";
            Maquillaje3.Precio = 395;
            Maquillaje3.Existencia = 20;
            Maquillaje3.Activo = true;

            ListaMaquillaje.Add(Maquillaje3);

            var Maquillaje4 = new Maquillaje();
            Maquillaje4.Id = 4;
            Maquillaje4.Descripcion = " L.A COLOR Base Truly Matte";
            Maquillaje4.Precio = 225;
            Maquillaje4.Existencia = 20;
            Maquillaje4.Activo = true;

            ListaMaquillaje.Add(Maquillaje4);

            var Maquillaje5 = new Maquillaje();
            Maquillaje5.Id = 5;
            Maquillaje5.Descripcion = " BEAUTY CREATION Poreless Primer";
            Maquillaje5.Precio = 250;
            Maquillaje5.Existencia = 20;
            Maquillaje5.Activo = true;

            ListaMaquillaje.Add(Maquillaje5);


            var Maquillaje6 = new Maquillaje();
            Maquillaje6.Id = 6;
            Maquillaje6.Descripcion = "TOO FACED Deliniador Better tha sex";
            Maquillaje6.Precio = 1147;
            Maquillaje6.Existencia = 10;
            Maquillaje6.Activo = true;

            ListaMaquillaje.Add(Maquillaje6);

            var Maquillaje7 = new Maquillaje();
            Maquillaje7.Id = 7;
            Maquillaje7.Descripcion = "WET N WILD Deliniador Liquido Mega Liner ";
            Maquillaje7.Precio = 196;
            Maquillaje7.Existencia = 10;
            Maquillaje7.Activo = true;

            ListaMaquillaje.Add(Maquillaje7);

            var Maquillaje8 = new Maquillaje();
            Maquillaje8.Id = 8;
            Maquillaje8.Descripcion = "MAC COSMETICS Labiales Mac Travel Exclusive ";
            Maquillaje8.Precio = 990;
            Maquillaje8.Existencia = 5;
            Maquillaje8.Activo = true;

            ListaMaquillaje.Add(Maquillaje8);

            var Maquillaje9 = new Maquillaje();
            Maquillaje9.Id = 9;
            Maquillaje9.Descripcion = "BEAUTY CREATIONS Lispstick barra Matte";
            Maquillaje9.Precio = 120;
            Maquillaje9.Existencia = 20;
            Maquillaje9.Activo = true;

            ListaMaquillaje.Add(Maquillaje9);

            var Maquillaje10 = new Maquillaje();
            Maquillaje10.Id = 10;
            Maquillaje10.Descripcion = "BEAUTY CREATIONS Mascara Thickening ";
            Maquillaje10.Precio = 290;
            Maquillaje10.Existencia = 15;
            Maquillaje10.Activo = true;

            ListaMaquillaje.Add(Maquillaje10);

            var Maquillaje11 = new Maquillaje();
            Maquillaje11.Id = 11;
            Maquillaje11.Descripcion = "BE BELLA Set De Brochas 24 Pcs Take Me To Malibu  ";
            Maquillaje11.Precio = 790;
            Maquillaje11.Existencia = 15;
            Maquillaje11.Activo = true;

            ListaMaquillaje.Add(Maquillaje11);

            var Maquillaje12 = new Maquillaje();
            Maquillaje12.Id = 12;
            Maquillaje12.Descripcion = "SUGAR KISS Set De Brochas 10 Piezas ";
            Maquillaje12.Precio = 290;
            Maquillaje12.Existencia = 15;
            Maquillaje12.Activo = true;

            ListaMaquillaje.Add(Maquillaje12);

            var Maquillaje13 = new Maquillaje();
            Maquillaje13.Id = 13;
            Maquillaje13.Descripcion = "CANDICE Set De Brochas 24 Piezas - Candice";
            Maquillaje13.Precio = 297;
            Maquillaje13.Existencia = 15;
            Maquillaje13.Activo = true;

            ListaMaquillaje.Add(Maquillaje13);

        }

        public BindingList<Maquillaje> ObtenerMaquillaje()
        {
            return ListaMaquillaje;
        }

        public Resultado GuardarMaquillaje(Maquillaje maquillaje)  //Creando la clase guardar producto//
        {
            var resultado = Validar(maquillaje);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }
            if (maquillaje.Id == 0)
            {
                maquillaje.Id = ListaMaquillaje.Max(item => item.Id) + 1;   //Función para Busca el número mayor y le suma 1//
            }
            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarMaquillaje()             //Creando la funcion agregar nuevo producto//
        {
            var nuevoMaquillaje = new Maquillaje();
            ListaMaquillaje.Add(nuevoMaquillaje);
        }

        public bool EliminarMaquillaje(int id)   //Creando la función eliminar //
        {
            foreach (var maquilla in ListaMaquillaje)
            {
                if (maquilla.Id == id)
                {                                       //Ciclo para buscar el producto deseado y luego ser borrado//
                    ListaMaquillaje.Remove(maquilla);     //Lista para recorrer objetos//
                    return true;
                }
            }
            return false;
        }

        private Resultado Validar(Maquillaje maquillaje)  // Función para Validaciones//

        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(maquillaje.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una descripción";
                resultado.Exitoso = false;
            }
            if (maquillaje.Existencia < 0)
            {
                resultado.Mensaje = "La existencia debe ser mayor que cero";
                resultado.Exitoso = false;
            }
            if (maquillaje.Precio < 0)
            {
                resultado.Mensaje = "El precio debe ser mayor que cero";
                resultado.Exitoso = false;
            }

            return resultado;
        }



        public class Maquillaje
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public double Precio { get; set; }
            public int Existencia { get; set; }
            public bool Activo { get; set; }


        }

        public class Resultado                     //Se creo la clase de Resultado//
        {
            public bool Exitoso { get; set; }
            public string Mensaje { get; set; }
        }




    }

    


}
