using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using HelpDesk.Dominio.Entidades;

namespace HelpDesk.Repositorio.Mapeamento
{
    public class RepositorioPaises : RepositorioBase<Paises>
    {
        public RepositorioPaises(ISession session)
            : base(session)
        {
        }

    }
}
