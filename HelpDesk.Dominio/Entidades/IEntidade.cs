using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Dominio.Entidades
{
    public interface IEntidade
    {
        Int64 ID { get; set; }
        Situacao Situacao { get; set; }

        String Validar();
    }
}
