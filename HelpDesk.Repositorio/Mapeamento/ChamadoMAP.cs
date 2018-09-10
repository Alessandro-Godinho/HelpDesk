using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using HelpDesk.Dominio.ObjetosValor;
using HelpDesk.Dominio.Entidades;

namespace HelpDesk.Repositorio.Mapeamento
{
    public class ChamadoMAP : ClassMap<Chamado>
    {
        public ChamadoMAP()
        {
            Id(x => x.ID)
                .GeneratedBy.HiLo("0");

            Map(x => x.DataAbertura);

            Map(x => x.DataFechamento);

            References(x => x.Cliente);

            Map(x => x.Usuario);

            Map(x => x.TipoOcorrencia)
                .CustomType<TipoOcorrencia>();

            Map(x => x.Descricao)
                .Length(200);

            Map(x => x.SituacaoChamado)
                .CustomType<SituacaoChamado>();

            Map(x => x.Situacao)
                .CustomType<Situacao>();

            HasMany(x => x.Historicos)
                .KeyColumn("Chamado_Id")
                .AsBag()
                .Cascade.AllDeleteOrphan()
                .Not.Inverse();
        }
    }
}
