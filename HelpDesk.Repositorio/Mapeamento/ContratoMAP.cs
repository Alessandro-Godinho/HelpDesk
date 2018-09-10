using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using HelpDesk.Dominio.ObjetosValor;
using HelpDesk.Dominio.Entidades;

namespace HelpDesk.Repositorio.Mapeamento
{
    public class ContratoMAP : ClassMap<Contrato>
    {
        public ContratoMAP()
        {
            Id(x => x.ID)
                .GeneratedBy.HiLo("0");

            Map(x => x.DataInicio);

            Map(x => x.DataTermino);

            References(x => x.Cliente);

            References(x => x.Software);

            Map(x => x.Descricao)
               .Length(200);

            Map(x => x.Situacao)
                .CustomType<Situacao>();

        }
    }
}
