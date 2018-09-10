using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.Entidades;
using NHibernate;

namespace HelpDesk.Repositorio.Mapeamento
{
    class RepositorioScriptBanco : RepositorioBase<ScriptBanco>
    {
        public RepositorioScriptBanco(ISession session)
            : base(session)
        {
        }
    }
}
