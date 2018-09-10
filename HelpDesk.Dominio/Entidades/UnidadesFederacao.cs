using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Dominio.Entidades
{
    public class UnidadesFederacao : IEntidade
    {
        /// <summary>
        /// Propriedade não mapeada, criada apenas para implementar IEntidade
        /// </summary>
        public virtual Int64 ID { get; set; }
        public virtual String UF { get; set; }
        public virtual Int16 Codigo { get; set; }
        public virtual String Nome { get; set; }
        public virtual Paises Pais { get; set; }
        public virtual Situacao Situacao { get; set; }

        public virtual String Validar()
        {
            String erro = String.Empty;
            if (String.IsNullOrEmpty(Nome))
            erro = "Campo NOME deve ser preenchido!";

            return erro;
        }
        public override string ToString()
        {
            return String.Format("{0}", UF);
        }
    }



}
