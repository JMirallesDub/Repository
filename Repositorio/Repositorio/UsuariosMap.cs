using System.Data.Entity.ModelConfiguration;

namespace Repositorio
{
    internal class UsuariosMap : EntityTypeConfiguration<Usuario>
    {
        public UsuariosMap()
        {
            HasKey(p => p.Id);
            Property(p => p.Age).IsOptional();
            Property(p => p.CreatedOn).IsRequired();
            Property(p => p.Id).IsRequired();
            Property(p => p.Name).IsOptional().HasMaxLength(250);


        }
    }
}
