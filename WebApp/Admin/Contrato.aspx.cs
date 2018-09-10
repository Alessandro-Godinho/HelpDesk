using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelpDesk.Repositorio;
using HelpDesk.Dominio.ObjetosValor;

namespace WebApp.Admin
{
    public partial class Contrato : System.Web.UI.Page
    {

        private RepositorioContrato _repositorio;
        public RepositorioContrato Repositorio
        {
            get
            {
                if (_repositorio == null)
                    _repositorio = new RepositorioContrato(NHibernateHttpModule.CurrentSession);

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
            if (!chkMostrarInativos.Checked)
                gvwDados.DataSource = Repositorio.ObterTodos(Situacao.Ativo);
            else
                gvwDados.DataSource = Repositorio.ObterTodos(Situacao.Inativo);

            gvwDados.DataBind();
        }
        protected void btnExcluir_Load(object sender, EventArgs e)
        {
            ((ImageButton)sender).Visible = !chkMostrarInativos.Checked;
        }

        protected void btnRecuperar_Load(object sender, EventArgs e)
        {
            ((ImageButton)sender).Visible = chkMostrarInativos.Checked;
        }

        protected void lnkNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ContratoCadastro.aspx");
        }

        protected void btnAlterar_Click(object sender, ImageClickEventArgs e)
        {
            HelpDesk.Dominio.Entidades.Contrato contrato = gvwDados.GetRow(gvwDados.FocusedRowIndex) as HelpDesk.Dominio.Entidades.Contrato;
            Response.Redirect(String.Format("~/Admin/ContratoCadastro.aspx?id={0}", contrato.ID));

        }

        protected void btnExluir_Click(object sender, ImageClickEventArgs e)
        {
            HelpDesk.Dominio.Entidades.Contrato contrato = gvwDados.GetRow(gvwDados.FocusedRowIndex) as HelpDesk.Dominio.Entidades.Contrato;
            contrato.Situacao = (contrato.Situacao.Equals(Situacao.Ativo) ? Situacao.Inativo : Situacao.Ativo);
            try
            {
                Repositorio.Alterar(contrato);
                CarregaGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }    
    }
}