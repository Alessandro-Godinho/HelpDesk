using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using HelpDesk.Dominio.Entidades;

namespace HelpDesk.Repositorio
{
    public class RepositorioCidade : RepositorioBase<Cidades>
    {
        public RepositorioCidade(ISession session)
            : base(session)
        {
        }
    }
}
