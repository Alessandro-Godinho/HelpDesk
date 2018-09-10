using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.Entidades;
using FluentNHibernate.Mapping;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Repositorio.Mapeamento
{
    public class CidadeMAP : ClassMap<Cidades>
    {
        public CidadeMAP()
        {
            Id(x => x.ID)
                .GeneratedBy.HiLo("0");

            Map(x => x.Nome)
                .Length(100);

            Map(x => x.CepPadrao);
                

            Map(x => x.Situacao)
                .CustomType<Situacao>();
        }

    }
}
