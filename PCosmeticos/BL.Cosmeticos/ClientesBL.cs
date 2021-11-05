using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Cosmeticos
{
    public class ClientesBL
    {
        public BindingList<Cliente> ListaClientes {  get;   set;}

        public ClientesBL()
        {
            ListaClientes = new BindingList<Cliente>();

            var cliente1 = new Cliente ();
            cliente1.Id = 1;
            cliente1.Nombre = "Maria Corrales";
            cliente1.Activo = true;

            ListaClientes.Add(cliente1);

            var cliente2 = new Cliente();
            cliente2.Id = 2;
            cliente2.Nombre = "Sandra Mejia";
            cliente2.Activo = true;

            ListaClientes.Add(cliente2);

        }
        public BindingList<Cliente> ObtenerCliente()
        {
            return ListaClientes;
        }
    }
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

    }
}
