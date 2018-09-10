using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Dominio.Entidades
{

    public class Atualizacao : IEntidade
    {
        public virtual Int64 ID { get; set; }
        public virtual DateTime DataAtualizacao { get; set; }
        public virtual Cliente Clientes { get; set; }
        public virtual Situacao Situacao { get; set; }
        public virtual String Usuario { get; set; }

        public virtual String Validar()
        {
            StringBuilder erro = new StringBuilder();

            if (String.IsNullOrEmpty(Usuario))
                erro.AppendLine("O Campo Nome deve ser preenchido!");

            return erro.ToString();
        }

        public override string ToString()
        {
            return Usuario;
        }
    }
}
