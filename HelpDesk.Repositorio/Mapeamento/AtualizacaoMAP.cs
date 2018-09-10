using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using HelpDesk.Dominio.Entidades;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Repositorio.Mapeamento
{
    public class AtualizacaoMAP : ClassMap<Atualizacao>
    {
        public AtualizacaoMAP()
        {
            Id(x => x.ID)
                .GeneratedBy.HiLo("0");

            Map(x => x.DataAtualizacao);


            Map(x => x.Usuario);
                

            Map(x => x.Situacao)
                .CustomType<Situacao>();

            References(x => x.Clientes);

        }
    }
}
