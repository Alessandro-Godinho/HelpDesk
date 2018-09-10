using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using HelpDesk.Dominio.Entidades;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Repositorio.Mapeamento
{
    public class AtendimentoMAP : ClassMap<Atendimento>
    {
        public AtendimentoMAP()
        {
            Id(x => x.ID)
                .GeneratedBy.HiLo("0");

            References(x => x.Chamado);

            Map(x => x.Situacao)
                .CustomType<Situacao>();


        }
    }
}
