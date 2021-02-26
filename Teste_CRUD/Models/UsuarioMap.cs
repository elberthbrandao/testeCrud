using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_CRUD.Models
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(u => u.id);
            Map(u => u.nome);
            Map(u => u.email);
            Table("usuario");
        }
    }
}
