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
    public partial class Atualizacao: System.Web.UI.Page
    {

        private RepositorioAtualizacao _repositorio;
        public RepositorioAtualizacao Repositorio
        {
            get
            {
                if (_repositorio == null)
                    _repositorio = new RepositorioAtualizacao(NHibernateHttpModule.CurrentSession);

                return _repositorio;
            }
            set { _repositorio = value; }
        }
     
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               // CarregaClientes();
                CarregaGrid();
            }
            else
            {
                if (chkVerTodos.Checked == true)
                    CarregaGrid();
              //  else
               //     CarregaGridPorParametro();
            }
        }

        private void CarregaGrid()
        {
          
            if (!chkMostrarInativos.Checked)
                gvwDados.DataSource = Repositorio.ObterTodos(Situacao.Ativo);
            else
                gvwDados.DataSource = Repositorio.ObterTodos(Situacao.Inativo);

            gvwDados.DataBind();
            chkVerTodos.Checked = true;
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
            Response.Redirect("~/Admin/AtualizacaoCadastro.aspx");
        }

        protected void btnAlterar_Click(object sender, ImageClickEventArgs e)
        {
            HelpDesk.Dominio.Entidades.Atualizacao software = gvwDados.GetRow(gvwDados.FocusedRowIndex) as HelpDesk.Dominio.Entidades.Atualizacao;
            Response.Redirect(String.Format("~/Admin/AtualizacaoCadastro.aspx?id={0}", software.ID));

        }

        protected void btnExluir_Click(object sender, ImageClickEventArgs e)
        {
            HelpDesk.Dominio.Entidades.Atualizacao software = gvwDados.GetRow(gvwDados.FocusedRowIndex) as HelpDesk.Dominio.Entidades.Atualizacao;
            software.Situacao = (software.Situacao.Equals(Situacao.Ativo) ? Situacao.Inativo : Situacao.Ativo);
            try
            {
                Repositorio.Alterar(software);
                CarregaGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /*private void CarregaClientes()
        {
            RepositorioCliente RepClientes = new RepositorioCliente(NHibernateHttpModule.CurrentSession);
            IList<HelpDesk.Dominio.Entidades.Cliente> clientes = RepClientes.ObterTodos();
            cmbCliente.DataSource = clientes;
            cmbCliente.DataBind();
        }*///carrega todos os clientes na combobox
        /*private void CarregaGridPorParametro()
        {
            chkVerTodos.Checked = false;
            IDictionary<String, Object> lista = new Dictionary<String, Object>();
            lista.Add("Clientes.ID", Int64.Parse(cmbCliente.SelectedValue));
            gvwDados.DataSource = Repositorio.ObterPorParametros(lista);
            cmbCliente.DataBind();
            gvwDados.DataBind();
        }

        protected void cmbCliente_TextChanged(object sender, EventArgs e)
        {
            CarregaGridPorParametro();
        }
        */ //filtrar atravez de uma combo box

        

        
    }
}