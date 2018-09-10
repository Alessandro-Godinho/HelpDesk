using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Dominio.Entidades
{
    public class Atendimento : IEntidade
    {
        public virtual Int64 ID { get; set; }
        public virtual String Status { get; set; }
        public virtual String Usuario { get; set; }
        public virtual Chamado Chamado { get; set; }

        public virtual Situacao Situacao { get; set; }

        public virtual String Validar()
        {
            String erro = String.Empty;
            if (String.IsNullOrEmpty(Status))
                erro = "Campo STATUS deve ser preenchido!";

            return erro;
        }
    }
}
