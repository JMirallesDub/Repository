using System;
using System.Data.Entity;

namespace Repositorio
{

    public class AppContext : DbContext
    {

        public AppContext()
        {
           
        }

        public AppContext(string connString = "Server=DESKTOP-NRLHVKS;Database=myDataBase;Trusted_Connection=True;")
        : base(connString)
        {
            // required by migrations
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Configurations.Add(new UsuariosMap());
            modelBuilder.Configurations.Add(new AddressesMap());
        }
    }
}
