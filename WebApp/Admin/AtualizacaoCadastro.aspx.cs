using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelpDesk.Repositorio;
using HelpDesk.Dominio.ObjetosValor;
using System.Drawing;

namespace WebApp.Admin
{
    public partial class AtualizacaoCadastro : System.Web.UI.Page
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

        private Int64 ID;
        HelpDesk.Dominio.Entidades.Atualizacao software;

        protected void Page_Load(object sender, EventArgs e)
        {
            data_atualizacao.Focus();

            try
            {
                ID = int.Parse(Request.QueryString["ID"]);
            }
            catch (Exception)
            {

            }
            if (!IsPostBack)
            {
                CarregaClientes();
                if (!ID.Equals(0))
                {
                     RepositorioCliente RepClientes = new RepositorioCliente(NHibernateHttpModule.CurrentSession);
                    IList<HelpDesk.Dominio.Entidades.Cliente> clientes = RepClientes.ObterTodos();
                    software = Repositorio.ObterPorId(ID);
                    data_atualizacao.Date = software.DataAtualizacao;
                    cmbCliente.SelectedIndex = clientes.IndexOf(software.Clientes);
                }
            }

          

        }

        protected void lnkOK_Click(object sender, EventArgs e)
        {
            RepositorioCliente RepClientes = new RepositorioCliente(NHibernateHttpModule.CurrentSession);    
            try
            {
                software = new HelpDesk.Dominio.Entidades.Atualizacao();
                software.DataAtualizacao = data_atualizacao.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
                software.Situacao = HelpDesk.Dominio.ObjetosValor.Situacao.Ativo;
                software.Usuario = Page.User.Identity.Name.Trim();
                software.Clientes= RepClientes.ObterPorId(Int64.Parse(cmbCliente.SelectedValue.ToString()));


                if (ID == 0)
                    Repositorio.Salvar(software);
                else
                {
                    software.ID = ID;
                    Repositorio.Alterar(software);
                }

                Response.Redirect("Atualizacao.aspx");
            }
            catch (ArgumentException ex)
            {
                data_atualizacao.Focus();
                return;
            }
            catch (Exception ex)
            {

            }
        }
        private void CarregaClientes()
        {
            RepositorioCliente RepClientes = new RepositorioCliente(NHibernateHttpModule.CurrentSession);
            IList<HelpDesk.Dominio.Entidades.Cliente> clientes = RepClientes.ObterTodos(Situacao.Ativo);
            cmbCliente.DataSource = clientes;
            cmbCliente.DataBind();
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Atualizacao.aspx");
        }
    }
}