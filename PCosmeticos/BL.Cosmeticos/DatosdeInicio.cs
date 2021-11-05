using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.Cosmeticos.SeguridadBL;

namespace BL.Cosmeticos
{
    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)

        {
            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = "FanyAmaya";
            usuarioAdmin.Contrasena = "Cosmeticoszare";

            contexto.Usuarios.Add(usuarioAdmin);


            var categoria1 = new Categoria();
            categoria1.Descripcion = "Cremas";
            contexto.Categorias.Add(categoria1); 


            var categoria2 = new Categoria();
            categoria2.Descripcion = "Mascarillas Faciales";
            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria3.Descripcion = "Jabon ";
            contexto.Categorias.Add(categoria3);

            var categoria4 = new Categoria();
            categoria4.Descripcion = "Aceites";
            contexto.Categorias.Add(categoria4);

            var tipo1 = new Tipo();
            tipo1.Descripcion = "Productos Faciales";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Esponjas";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Maquillaje";
            contexto.Tipos.Add(tipo3);



            base.Seed(contexto);

        }


    }
}