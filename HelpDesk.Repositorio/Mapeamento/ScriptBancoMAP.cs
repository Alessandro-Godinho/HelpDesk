using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using HelpDesk.Dominio.Entidades;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Repositorio.Mapeamento
{
   public class ScriptBancoMAP : ClassMap<ScriptBanco>
    {
        public ScriptBancoMAP()
        {
            Id(x => x.ID).GeneratedBy.HiLo("0");

            Map(x => x.Descricao);

            Map(x => x.DataScript);

            Map(x => x.LinkScript).Length(5000);

            Map(x => x.Script).Length(5000);

            Map(x => x.Situacao)
                .CustomType<Situacao>();

        }

    }
}
