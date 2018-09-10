using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Dominio.Entidades
{
    public class Usuario : IEntidade
    {
        public virtual Int64 ID { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Login { get; set; }
        public virtual Situacao Situacao { get; set; }

        public virtual String Validar()
        {
            String erro = String.Empty;
            if (String.IsNullOrEmpty(Nome))
                erro = "Campo NOME deve ser preenchido!";

            return erro;
        }

        public override string ToString()//aqui ele retorna os caracteres subscritos como a propriedade da classe
        {
            return Nome;
        }
    }
}
