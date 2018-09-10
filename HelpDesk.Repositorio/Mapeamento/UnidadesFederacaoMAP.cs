using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using HelpDesk.Dominio.Entidades;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Repositorio.Mapeamento
{
    public class UnidadesFederacaoMAP : ClassMap<UnidadesFederacao>
    {
        public UnidadesFederacaoMAP()
        {
            Id(x => x.UF)
                .Length(2)
                .GeneratedBy.Assigned();

            Map(x => x.Codigo);

            Map(x => x.Nome)
                .Length(100);

            References(x => x.Pais);

            Map(x => x.Situacao)
                .CustomType<Situacao>();
        }
    }
}
