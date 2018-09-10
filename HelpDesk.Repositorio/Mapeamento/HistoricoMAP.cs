using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using HelpDesk.Dominio.Entidades;
using HelpDesk.Dominio.ObjetosValor;


namespace HelpDesk.Repositorio.Mapeamento
{
    public class HistoricoMAP : ClassMap<Historico>
    {
        public HistoricoMAP()
        {
            Id(x => x.ID)
                .GeneratedBy.HiLo("0");

            Map(x => x.DataHistorico);

            Map(x => x.Descricao)
                .Length(250);

            Map(x => x.Usuario);

            References(x => x.Chamado, "Chamado_Id");

            Map(x => x.Situacao)
                .CustomType<Situacao>();
        }
    }
}
