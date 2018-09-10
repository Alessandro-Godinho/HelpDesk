using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelpDesk.Repositorio;
using HelpDesk.Dominio.ObjetosValor;
using HelpDesk.Dominio.Entidades;//mudei aqui 
using System.Data.SqlClient;

namespace WebApp
{
    public partial class Chamado : System.Web.UI.Page
    {
        private RepositorioChamado _repositorio;

        private object cha = null;
        public RepositorioChamado Repositorio
        {
            get
            {
                if (_repositorio == null)
                    _repositorio = new RepositorioChamado(NHibernateHttpModule.CurrentSession);

                return _repositorio;
            }
            set { _repositorio = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            CarregaGrid();
        }

        private void CarregaGrid()
        {
            gvwDados.DataSource = Repositorio.ObterTodos(Situacao.Ativo);
            gvwDados.DataBind();
        
        }
        

        protected void lnkNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChamadoCadastro.aspx");
        }

        protected void btnAlterar_Click(object sender, ImageClickEventArgs e)
        {
            HelpDesk.Dominio.Entidades.Chamado chamado = gvwDados.GetRow(gvwDados.FocusedRowIndex) as HelpDesk.Dominio.Entidades.Chamado;
            Response.Redirect(String.Format("~/AlterarChamado.aspx?id={0}", chamado.ID));

        }

        protected void btnExluir_Click(object sender, ImageClickEventArgs e)
        {
            HelpDesk.Dominio.Entidades.Chamado chamado = gvwDados.GetRow(gvwDados.FocusedRowIndex) as HelpDesk.Dominio.Entidades.Chamado;
            chamado.Situacao = (chamado.Situacao.Equals(Situacao.Ativo) ? Situacao.Inativo : Situacao.Ativo);
            try
            {
                Repositorio.Alterar(chamado);
                CarregaGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}