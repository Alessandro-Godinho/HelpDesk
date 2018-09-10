using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using HelpDesk.Dominio.Entidades;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Repositorio.Mapeamento
{
    public class PaisesMAP : ClassMap<Paises>
    {
        public PaisesMAP()
        {
            Id(x => x.ID)
                .GeneratedBy.HiLo("0");

            Map(x => x.Nome)
                .Length(100);

            Map(x => x.Situacao)
                .CustomType<Situacao>();
        }
    }
}
