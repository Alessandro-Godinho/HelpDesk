using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Dominio.Entidades
{
    public class Cidade : IEntidade
    {
        public virtual Int64 ID { get; set; }
        public virtual String Nome { get; set; }
        public virtual String UF { get; set; }
        public virtual Situacao Situacao { get; set; }

        public virtual String Validar()
        {
            StringBuilder erro = new StringBuilder();

            if (String.IsNullOrEmpty(Nome))
                erro.AppendLine("O Campo Nome deve ser preenchido!");
           
            if (UF == null)
                erro.AppendLine("O Campo Unidade Federal deve ser preenchido");

            return erro.ToString();
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", Nome, UF);
        }
    }
}
