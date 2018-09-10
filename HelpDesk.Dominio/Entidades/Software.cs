using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Dominio.Entidades
{

    public class Software : IEntidade
    {
        public virtual Int64 ID { get; set; }
        public virtual String Nome { get; set; }
        public virtual Linguagem Linguagem { get; set; }
        public virtual Situacao Situacao { get; set; }

        public virtual String Validar()
        {
            StringBuilder erro = new StringBuilder();

            if (String.IsNullOrEmpty(Nome))
                erro.AppendLine("O Campo Nome deve ser preenchido!");

            return erro.ToString();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
