using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.Entidades;
using NHibernate;
using NHibernate.Criterion;


namespace HelpDesk.Repositorio
{
    public class RepositorioUnidadesFederacao : RepositorioBase<UnidadesFederacao>
    {
        public RepositorioUnidadesFederacao(ISession session)
            : base(session)
        {

        }
        public override IList<UnidadesFederacao> ObterTodos(Dominio.ObjetosValor.Situacao situacao)
        {
            var entidades = this
               .Session
               .CreateCriteria(typeof(UnidadesFederacao)).Add(Expression.Eq("Situacao", situacao))
               .AddOrder(Order.Asc("UF"))
               .List<UnidadesFederacao>();
            return entidades;
        }
       
    

    }
}
