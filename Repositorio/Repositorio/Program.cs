using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    class Program
    {
        static void Main(string[] args)
        {            string connectionStrin = "Server=DESKTOP-NRLHVKS;Database=myDataBase;Trusted_Connection=True;";

            var context = new AppContext(connectionStrin);
            context.Database.Initialize(true);
        
            
            //var repositorio = new EfRepository<Usuario>(new AppContext(connectionStrin));

            //repositorio.Add(new Usuario() { Id = 1, Name = "Jose", Age = 48, CreatedOn = DateTime.Today.ToUniversalTime() });
            //repositorio.Add(new Usuario() { Id = 2, Name = "Santiago y cierra Espanha", Age = 38, CreatedOn = DateTime.Today.ToUniversalTime(), Direcciones = new List<Address>() { new Address() { Country ="Ireland", CreatedOn = DateTime.Now.ToUniversalTime(), Id = 1, IsActive = true, Number ="69", PostalCode = "ERI12", Street = "C. Se conho", Type = 1, UserId = 2 } } });

        }
    }
}
