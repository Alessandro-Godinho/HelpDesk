using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Dominio.Entidades
{
    public class Contrato : IEntidade
    {
        public virtual Int64 ID { get; set; }
        public virtual DateTime DataInicio { get; set; }
        public virtual DateTime DataTermino { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Atualizacao Software { get; set; }
        public virtual String Descricao { get; set; }
        public virtual Situacao Situacao { get; set; }

        public virtual String Validar()
        {
            StringBuilder erro = new StringBuilder();
             
            if (DataInicio == new DateTime())
                erro.AppendLine("O Campo Data de Início deve ser preenchido");

            if (DataTermino.Date < DataInicio.Date)
            {
                erro.AppendLine("O Campo data de término é anterior a data de início Por favor verifique as mesmas ");
            }

            if(DataTermino == new DateTime())
               erro.AppendLine("O Campo Data de Termino deve ser preenchido");

            if (String.IsNullOrEmpty(Convert.ToString(Cliente)))
                erro.AppendLine("O Campo Cliente deve der preenchido");


            return erro.ToString();
        }
    }
}
