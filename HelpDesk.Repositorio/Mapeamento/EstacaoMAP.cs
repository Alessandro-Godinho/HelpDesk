using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using HelpDesk.Dominio.Entidades;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Repositorio.Mapeamento
{
   public class EstacaoMAP : ClassMap<Estacao>
    {
       public EstacaoMAP()
       {
           Id(x => x.ID)
    .GeneratedBy.HiLo("0");

           Map(x => x.NomeComputador);

           Map(x => x.Solicitante);

           Map(x => x.SistemaOperacional);

           Map(x => x.IP);

           Map(x => x.IdentificacaoRemota);

           Map(x => x.UsuarioRoot);

           Map(x => x.SenhaRoot);

           Map(x => x.UsuarioAdministrador);

           Map(x => x.SenhaAdministrador);

           Map(x => x.Adicionais).Length(2000);

           Map(x => x.Situacao)
               .CustomType<Situacao>();

           References(x => x.Clientes);
       }
       
    }
}
