using System.Data.Entity.ModelConfiguration;

namespace Repositorio
{
    internal class AddressesMap : EntityTypeConfiguration<Address>
    {
        public AddressesMap()
        {
            HasKey(p => p.Id);
            Property(p => p.Country).IsOptional();
            Property(p => p.CreatedOn).IsRequired();
            Property(p => p.Id).IsRequired();
            Property(p => p.Street).IsOptional().HasMaxLength(250);
            Property(p => p.IsActive).IsRequired();
            Property(p => p.Number).IsRequired();
            Property(p => p.PostalCode).IsOptional();
            Property(p => p.Type).IsRequired();
            Property(p => p.UserId).IsRequired();

            HasRequired(t => t.Usuario).WithMany().HasForeignKey(t => t.UserId);



        }
    }
}