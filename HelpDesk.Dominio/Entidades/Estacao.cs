using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Dominio.Entidades
{
     public class Estacao : IEntidade
    {

        public virtual Int64 ID { get; set; }
        public virtual String NomeComputador{ get; set; }
        public virtual String Solicitante { get; set; }
        public virtual String SistemaOperacional { get; set; }
        public virtual String IP { get; set; }
        public virtual String IdentificacaoRemota { get; set; }
        public virtual String UsuarioRoot { get; set; }
        public virtual String SenhaRoot{ get; set; }
        public virtual String UsuarioAdministrador{ get; set; }
        public virtual String SenhaAdministrador { get; set; }
        public virtual String Adicionais { get; set; }
        public virtual Cliente Clientes { get; set; }
        public virtual Situacao Situacao { get; set; }

        public virtual string Validar()
        {

            StringBuilder erro = new StringBuilder();

            if (String.IsNullOrEmpty(NomeComputador))
                erro.AppendLine("O Campo Nome deve ser preenchido!");

            return erro.ToString();
        }
        public override string ToString()
        {
            return NomeComputador;

        }
    }
}
