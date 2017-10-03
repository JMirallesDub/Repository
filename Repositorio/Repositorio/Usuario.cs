using System;
using System.Collections.Generic;

namespace Repositorio
{
    public class Usuario : BaseEntity
    {
        public Usuario()
        {

        }

        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual List<Address> Direcciones { get; set; }
    }
}