using Microsoft.EntityFrameworkCore;
using TiendaMVC.Models;

namespace TiendaMVC.Servicios
{
    /*
    Representa el contexto de base de datos de la aplicación.
    Contiene los DbSet que se mapearán como tablas en la base de datos.
    */
    public class AplicacionDbContext : DbContext
    {
        /*
        Constructor del contexto que recibe las opciones de configuración
        (como la cadena de conexión) a través de inyección de dependencias.
        
        Recibe como parametro opciones de configuración del contexto.
        */
        public AplicacionDbContext(DbContextOptions options) : base(options) 
        {
            
        }
        //Representa la tabla de productos en la base de datos.
        public DbSet<Producto> Productos{ get; set; }
    }
}
