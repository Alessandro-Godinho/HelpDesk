using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using HelpDesk.Dominio.Entidades;

using HelpDesk.Dominio.ObjetosValor;

namespace HelpDesk.Repositorio
{
    public class RepositorioBase<T> where T : IEntidade
    {
        ICriteria criterio;
        public RepositorioBase(ISession session)
        {
            if (session == null)
                throw new ArgumentException("A session deve existir.", "session");
            _session = session;
        }
        private readonly ISession _session;
        protected ISession Session
        {
            get { return _session; }
        }

        public void Salvar(T entidade)
        {
            String validacao = entidade.Validar();
            if (validacao != string.Empty)
                throw new ArgumentException(validacao);

            using (var trans = Session.BeginTransaction())
            {
                try
                {
                    this.Session.Save(entidade);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                   
                }
            }
        }
        public void SalvarLote(T entidade)
        {
            String validacao = entidade.Validar();
            if (validacao != string.Empty)
                throw new ArgumentException(validacao);

            try
            {
                this.Session.Save(entidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Alterar(T entidade)
        {
            using (var trans = Session.BeginTransaction())
            {
                try
                {
                    String validacao = entidade.Validar();
                    if (validacao != string.Empty)
                        throw new ArgumentException(validacao);

                    this.Session.Merge(entidade);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }
        public void AlterarLote(T entidade)
        {
            try
            {
                String validacao = entidade.Validar();
                if (validacao != string.Empty)
                    throw new ArgumentException(validacao);

                this.Session.Merge(entidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Excluir(T entidade)
        {
            using (var trans = Session.BeginTransaction())
            {
                try
                {
                    this.Session.Delete(entidade);
                    trans.Commit();
                }
                finally
                {
                    trans.Rollback();
                }
            }
        }
        public T ObterPorId(Int64 id)
        {
            var entidade = this.Session.Get<T>(id);
            return entidade;
        }

        public IList<T> ObterTodos()
        {
            var entidades = this
                .Session
                .CreateCriteria(typeof(T))
                .AddOrder(Order.Asc("ID"))
                .List<T>();
            return entidades;
        }

        public virtual IList<T> ObterTodos(Situacao situacao)
        {
            var entidades = this
                 .Session
                 .CreateCriteria(typeof(T)).Add(Expression.Eq("Situacao", situacao))
                 .AddOrder(Order.Asc("ID"))
                 .List<T>();
            return entidades;
        }

        public virtual IList<T> ObterPorParametros(IDictionary<String, Object> parametros, int Quantidade = 0, int primeiro = 0)
        {

            criterio = _session.CreateCriteria(typeof(T));
            CriaCriterios(parametros);

            if (Quantidade > 0)
                criterio.SetMaxResults(Quantidade);
            if (primeiro > 0)
                criterio.SetFirstResult(primeiro);

            try
            {
                return criterio.List<T>();
            }
            catch
            {
                throw;
            }
        }
        public T ObterPorParametros(IDictionary<String, Object> parametros, Boolean UniqueResult)
        {
            criterio = _session.CreateCriteria(typeof(T));
            CriaCriterios(parametros);
            try
            {
                return criterio.UniqueResult<T>();
            }
            catch
            {
                throw;
            }

        }

        public IList<T> ObterPorParametros(IDictionary<String, Object> parametros, IDictionary<String, String> Ordenacao, int Quantidade = 0, int primeiro = 0)
        {
            criterio = _session.CreateCriteria(typeof(T));
            CriaCriterios(parametros);

            foreach (var item in Ordenacao)
            {
                if (item.Key.Substring(0, 3).Equals("Asc"))
                    criterio.AddOrder(Order.Asc(item.Value));
                else
                    criterio.AddOrder(Order.Desc(item.Value));
            }
            if (Quantidade > 0)
                criterio.SetMaxResults(Quantidade);
            if (primeiro > 0)
                criterio.SetFirstResult(primeiro);

            try
            {
                return criterio.List<T>();
            }
            catch
            {
                throw;
            }

        }

        private void CriaCriterios(IDictionary<String, Object> parametros)
        {

            string Aliases = "_";

            foreach (var item in parametros)
            {
                string operador = string.Empty;
                string property;
                if (item.Key.IndexOf("[") > 0)
                {
                    operador = item.Key.Substring(item.Key.IndexOf("[") + 1, (item.Key.IndexOf("]") - item.Key.IndexOf("[")) - 1);
                    property = item.Key.Substring(0, item.Key.IndexOf("[")).Trim();
                }
                else
                {
                    operador = "=";
                    property = item.Key.Trim();
                }

                if (property.IndexOf(".") != -1)
                {
                    string key = property, alias = string.Empty;
                    Boolean bLoop = true;
                    while (bLoop)
                    {
                        if (key.IndexOf(".") == -1)
                            bLoop = false;
                        else
                        {
                            if (alias == string.Empty)
                                alias = key.Substring(0, key.IndexOf("."));
                            else
                                alias += "." + key.Substring(0, key.IndexOf("."));
                            if (Aliases.IndexOf(String.Format("_{0}_", alias)) == -1)
                            {
                                criterio.CreateAlias(alias, alias);
                                Aliases += String.Format("{0}_", alias);
                            }
                            key = key.Substring(key.IndexOf(".") + 1, (key.Length - key.IndexOf(".")) - 1);
                        }
                    }
                }

                if (operador.IndexOf("|") == -1)
                {
                    criterio.Add(AdicionaCriterio(operador, property, item.Value));
                }
                else
                {
                    int j = 0;
                    String[] operadores = operador.Split(("|").ToCharArray());
                    //Object[] param = (Object[])item.Value;

                    var Restricao = Restrictions.Disjunction();
                    foreach (var Operador in operadores)
                    {
                        Restricao.Add(AdicionaCriterio(Operador, property, item.Value));
                        criterio.Add(Restricao);
                        j++;
                    }
                }
            }
        }
        private ICriterion AdicionaCriterio(string operador, string property, Object Value)
        {
            ICriterion Criterion;
            switch (operador)
            {
                case "=":
                    Criterion = Expression.Eq(property, Value);
                    break;
                case "!=":
                    Criterion = Expression.Not(Expression.Eq(property, Value));
                    break;
                case "in":
                    Criterion = Expression.In(property, (String[])Value);
                    break;
                case "!in":
                    Criterion = Expression.Not(Expression.In(property, (String[])Value));
                    break;
                case "<>":
                    var dt = (DateTime[])Value;
                    Criterion = Expression.Between(property, dt[0], dt[1]);
                    break;
                case "><":
                    var dt2 = (DateTime[])Value;
                    Criterion = Expression.Not(Expression.Between(property, dt2[0], dt2[1]));
                    break;

                case ">":
                    Criterion = Expression.Gt(property, Value);
                    break;
                case ">=":
                    Criterion = Expression.Ge(property, Value);
                    break;
                case "<":
                    Criterion = Expression.Lt(property, Value);
                    break;
                case "<=":
                    Criterion = Expression.Le(property, Value);
                    break;
                case "null":
                    Criterion = Restrictions.IsNull(property);
                    break;
                case "!null":
                    Criterion = Restrictions.IsNotNull(property);
                    break;
                case "like":
                    Criterion = Restrictions.Like(property, Value);
                    break;
                default:
                    throw new Exception("Operador não identificado!");
            }
            return Criterion;
        }
    }
}
