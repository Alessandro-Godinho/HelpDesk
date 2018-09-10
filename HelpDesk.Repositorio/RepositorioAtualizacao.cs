using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.Entidades;
using NHibernate;

namespace HelpDesk.Repositorio
{
    public class RepositorioAtualizacao : RepositorioBase<Atualizacao>
    {
        public RepositorioAtualizacao(ISession session)
            : base(session)
        {
        }
    }
}
