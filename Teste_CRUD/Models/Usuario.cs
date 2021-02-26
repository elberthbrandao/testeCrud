using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_CRUD.Models
{
    public class Usuario
    {
        public virtual int id { get; set; }
        public virtual string nome { get; set; }
        public virtual string email { get; set; }
    }
}
