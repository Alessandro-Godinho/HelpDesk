﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using HelpDesk.Dominio.Entidades;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Repositorio.Mapeamento
{
    public class ClienteMAP : ClassMap<Cliente>
    {
        public ClienteMAP()
        {
            Id(x => x.ID)
                .GeneratedBy.HiLo("0");

            Map(x => x.Nome)
                .Length(100);

            Map(x => x.Cnpj)
                .Length(20);

            Map(x => x.InscricaoEstadual)
                .Length(20);

            Map(x => x.Endereco)
                .Length(100);

            Map(x => x.Bairro)
                .Length(100);

            Map(x => x.Cep)
                .Length(10);

            References(x => x.Cidade, "IdCidade");

            Map(x => x.Email)
                .Length(100);

            Map(x => x.Telefone)
                .Length(20);

            Map(x => x.Fax)
                .Length(20);

            Map(x => x.Celular)
                .Length(20);

            Map(x => x.Situacao)
                .CustomType<Situacao>();

        }
    }
}
