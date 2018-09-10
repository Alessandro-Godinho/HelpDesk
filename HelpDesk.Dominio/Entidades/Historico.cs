using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Dominio.Entidades
{
    public class Historico : IEntidade
    {
        public Historico()
        {
            this.Situacao = ObjetosValor.Situacao.Ativo;
       
        }

        public virtual Int64 ID { get; set; }
        public virtual DateTime DataHistorico { get; set; }
        public virtual String Descricao { get; set; }
        public virtual String Usuario { get; set; }
        public virtual Chamado Chamado { get; set; }
        public virtual Situacao Situacao { get; set; }

        public virtual String Validar()
        {
            String erro = String.Empty;
            if (String.IsNullOrEmpty(Descricao))
                erro = "Campo DESCRIÇÃO deve ser preenchido!";
            
            return erro;
        }

    }
}
