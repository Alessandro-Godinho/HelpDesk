using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.Entidades;
using NHibernate;

namespace HelpDesk.Repositorio
{
    public class RepositorioHistorico : RepositorioBase<Historico>
    {
        public RepositorioHistorico(ISession session)
            : base(session)
        {
        }
    }
}
