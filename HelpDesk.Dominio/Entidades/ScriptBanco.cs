using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Dominio.Entidades
{
    public class ScriptBanco : IEntidade
    {

        public virtual Int64 ID { get; set; }
        public virtual String Descricao { get; set; }
        public virtual DateTime DataScript { get; set; }
        public virtual String Script { get; set; }
        public virtual String LinkScript { get; set; }
        public virtual Situacao Situacao { get; set; }

        public virtual string Validar()
        {
            StringBuilder erro = new StringBuilder();
            if (Script == null)
                erro.Append("É necessario informar a data");
            return erro.ToString();

        }


        
    }
}
