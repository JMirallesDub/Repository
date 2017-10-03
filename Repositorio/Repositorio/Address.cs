using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class Address : BaseEntity
    {
        public long UserId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int Type { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
