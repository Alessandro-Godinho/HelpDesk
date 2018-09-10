using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.Entidades;
using NHibernate;

namespace HelpDesk.Repositorio
{
    public class RepositorioAtendimento : RepositorioBase<Atendimento>
    {
        public RepositorioAtendimento(ISession session)
            : base(session)
        {
        }
    }
}
