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
    public partial class Cliente : System.Web.UI.Page
    {

        private RepositorioCliente _repositorio;
        public RepositorioCliente Repositorio
        {
            get
            {
                if (_repositorio == null)
                    _repositorio = new RepositorioCliente(NHibernateHttpModule.CurrentSession);

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
            Response.Redirect("~/Admin/ClienteCadastro.aspx");
        }

        protected void btnAlterar_Click(object sender, ImageClickEventArgs e)
        {
            HelpDesk.Dominio.Entidades.Cliente cliente = gvwDados.GetRow(gvwDados.FocusedRowIndex) as HelpDesk.Dominio.Entidades.Cliente;
            Response.Redirect(String.Format("~/Admin/ClienteCadastro.aspx?id={0}", cliente.ID));

        }

        protected void btnExluir_Click(object sender, ImageClickEventArgs e)
        {
            HelpDesk.Dominio.Entidades.Cliente cliente = gvwDados.GetRow(gvwDados.FocusedRowIndex) as HelpDesk.Dominio.Entidades.Cliente;
            cliente.Situacao = (cliente.Situacao.Equals(Situacao.Ativo) ? Situacao.Inativo : Situacao.Ativo);
            try
            {
                Repositorio.Alterar(cliente);
                CarregaGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }    
    }
}