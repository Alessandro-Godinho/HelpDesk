using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Dominio.Entidades
{
    public class Chamado : IEntidade
    {
        public virtual Int64 ID { get; set; }
        public virtual DateTime DataAbertura { get; set; }
        public virtual DateTime DataFechamento { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual String Usuario { get; set; }
        public virtual TipoOcorrencia TipoOcorrencia { get; set; }
        public virtual String Descricao { get; set; }
        public virtual SituacaoChamado SituacaoChamado { get; set; }
        public virtual Situacao Situacao { get; set; }
        public virtual IList<Historico> Historicos { get; set; }

        public virtual String Validar()
        {
            StringBuilder erro = new StringBuilder();

            if (DataAbertura == new DateTime())
                erro.AppendLine("O Campo Data de Abertura deve ser preenchido");

            if (DataFechamento == new DateTime())
                erro.AppendLine("O Campo Data de Fechamento deve ser preenchido");

            if (DataFechamento.Date < DataAbertura.Date)
            {
                erro.AppendLine("O Campo Data de Término é anterior a data de início Por favor verifique as mesmas ");

            }

            if (String.IsNullOrEmpty(Convert.ToString(Cliente.ToString())))
                erro.AppendLine("O Campo Cliente deve ser preenchido");


            if (String.IsNullOrEmpty(Descricao))
               erro.AppendLine("O Campo Descrição deve ser preenchido!");

            return erro.ToString();
        }

    }
}
