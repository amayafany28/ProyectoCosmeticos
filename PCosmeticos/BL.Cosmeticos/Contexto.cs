using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BL.Cosmeticos
{
    public class Contexto: DbContext 
    {
        public Contexto(): base("Productos Faciales")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosdeInicio());
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public static object Usuarios { get; internal set; }
        public object Usuario { get; internal set; }
    }

}
