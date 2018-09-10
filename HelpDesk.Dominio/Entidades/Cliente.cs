using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Dominio.Entidades
{
    public class Cliente : IEntidade
    {
        public virtual Int64 ID { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Cnpj { get; set; }
        public virtual String InscricaoEstadual { get; set; }
        public virtual String Endereco { get; set; }
        public virtual String Bairro { get; set; }
        public virtual String Cep { get; set; }
        public virtual Cidades Cidade { get; set; }
        public virtual String Email { get; set; }
        public virtual String Telefone { get; set; }
        public virtual String Fax { get; set; }
        public virtual String Celular { get; set; }
        public virtual Situacao Situacao { get; set; }

        public virtual String Validar()
        {
            StringBuilder erro = new StringBuilder();
           
            if (String.IsNullOrEmpty(Nome))
                erro.AppendLine("O Campo Nome deve ser preenchido!");

            /*if (Cnpj.ToString() == null)
                erro.AppendLine("O Campo Cnpj deve ser preenchido");*/

            if (String.IsNullOrEmpty(InscricaoEstadual))
                erro.AppendLine("O Campo Inscrição Estadual deve ser preenchido");

            if (String.IsNullOrEmpty(Endereco))
                erro.AppendLine("O Campo Endereço deve ser preenchido");

            if (String.IsNullOrEmpty(Bairro))
                erro.AppendLine("O Campo Bairro deve ser preenchido");
           
            if (String.IsNullOrEmpty(Email))
                erro.AppendLine("O Campo Email deve ser preenchido");
                        
            if (Cidade == null)
                erro.AppendLine("O Campo Cidade deve ser preenchido");
            
            return erro.ToString();
        }

        public override string ToString()
        {
            return Nome;
            
        }

      


    }
}
